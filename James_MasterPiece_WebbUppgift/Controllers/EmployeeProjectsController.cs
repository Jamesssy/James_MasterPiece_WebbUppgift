using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;
using James_MasterPiece_WebbUppgift.Context;

namespace James_MasterPiece_WebbUppgift.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private readonly MasterPieceContext _context;

        public EmployeeProjectsController()
        {
            _context = new MasterPieceContext();
        }

        // GET: EmployeeProjects
        public async Task<ViewResult> Index(string sortOrder, string searchString)

        {
            
            var employeeProjects = _context.EmployeeProjects.Include(e => e.Employee).Select(e => e).Include(e => e.Project).Select(e => e);
            //var masterPieceContext = _context.EmployeeProjects.Include(e => e.Employee).Select(e => e).Include(e => e.Project).Select(e => e);




            ViewBag.ProjectNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProjectName_desc" : "";
          
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "firstName";
           




            if (!String.IsNullOrEmpty(searchString))
            {

                employeeProjects = employeeProjects.Where(s => 
                s.Employee.FirstName.Contains(searchString)
                || s.Employee.LastName.Contains(searchString)
                || s.Project.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName":
                    employeeProjects = employeeProjects.OrderBy(s => s.Employee.FirstName);
                    break;
                case "firstName_desc":
                    employeeProjects = employeeProjects.OrderByDescending(s => s.Employee.FirstName);
                    break;


                case "ProjectName_desc":
                    employeeProjects = employeeProjects.OrderByDescending(s => s.Project.Name);
                    break;
                
                
                default:
                    employeeProjects = employeeProjects.OrderBy(s => s.Project.Name);
                    break;
            }

            return View(await employeeProjects.ToListAsync());

            
            


        }


     

        // GET: EmployeeProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeProjects == null)
            {
                return NotFound();
            }

            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,ProjectId")] EmployeeProjects employeeProjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeProjects);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<IActionResult> Edit(int EmployeeId, int ProjectId)
        {
            EmployeeProjects ep = _context.EmployeeProjects.Find(EmployeeId, ProjectId);
            if (ep == null)
            {
                return NotFound();
            }

            //var employeeProjects = await _context.EmployeeProjects.SingleOrDefaultAsync(m => m.EmployeeId == EmployeeId);
            //if (employeeProjects == null)
            //{
            //    return NotFound();
            //}
            //ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", ep.EmployeeId);
            //ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", ep.ProjectId);
            ViewBag.EmployeeId = new SelectList(_context.Employee, "EmployeeId", "FirstName", ep.EmployeeId);
            ViewBag.ProjectId = new SelectList(_context.Project, "ProjectId", "ProjectName", ep.EmployeeId);
            return View(ep);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int EmployeeId, int ProjectId, [Bind("EmployeeId,ProjectId")] EmployeeProjects employeeProjects)
        {
            if (EmployeeId != employeeProjects.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeProjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeProjectsExists(employeeProjects.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Delete/5
        public async Task<IActionResult> Delete(int EmployeeId, int ProjectId )
        {
            EmployeeProjects ep =  _context.EmployeeProjects.Find(EmployeeId, ProjectId);
            if (ep == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .SingleOrDefaultAsync(m => m.EmployeeId == EmployeeId);
            if (employeeProjects == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", employeeProjects.EmployeeId);
            //ViewBag.EmployeeId = new SelectList(_context.Employee, "EmployeeId", "FirstName", ep.EmployeeId);
            ViewBag.ProjectId = new SelectList(_context.Project, "ProjectId", "ProjectName", ep.EmployeeId);
            return View(ep);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmployeeId, int ProjectId)
        {
            var employeeProjects = await _context.EmployeeProjects.SingleOrDefaultAsync(m => m.EmployeeId == EmployeeId);
            _context.EmployeeProjects.Remove(employeeProjects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeProjectsExists(int id)
        {
            return _context.EmployeeProjects.Any(e => e.EmployeeId == id);
        }

        //public void Update(Employee employee)
        //{
        //    MasterPieceContext contextAdapter = (MasterPieceContext)_context;
        //    MasterPieceContext stateManager = contextAdapter.EmployeeProjects.Where(s => s.EmployeeId = employee);

        //    stateManager.ChangeRelationshipState(existingParent, existingChild, "Roles", EntityState.Deleted);

        //    _context.SaveChanges();
        //}
    }

    
}
