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
    public class ProjectsController : Controller
    {
        private readonly MasterPieceContext _context;

        public ProjectsController()
        {
            _context = new MasterPieceContext();
        }


        public async Task<ViewResult> Index(string sortOrder, string searchString)

        {
            var projects = _context.Project.Select(s => s);
            

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "StartDate_desc" : "StartDate";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "EndDate_desc" : "EndDate";
            ViewBag.GoalEndDateSortParm = sortOrder == "GoalEndDate" ? "GoalEndDate_desc" : "GoalEndDate";
            ViewBag.ProjectNoSortParm = sortOrder == "ProjectNo" ? "ProjectNo_desc" : "ProjectNo";
            
            
      


            if (!String.IsNullOrEmpty(searchString))
            {

                projects = projects.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    projects = projects.OrderByDescending(s => s.EmployeeProjects.Select(e => e.Employee.FirstName));
                    break;


                case "name":
                    projects = projects.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    projects = projects.OrderByDescending(s => s.ProjectNo);
                    break;
                case "ProjectNo":
                    projects = projects.OrderBy(s => s.ProjectNo);
                    break;
                case "ProjectNo_desc":
                    projects = projects.OrderByDescending(s => s.ProjectNo);
                    break;
                case "StartDate":
                    projects = projects.OrderBy(s => s.StartDate);
                    break;
                case "StartDate_desc":
                    projects = projects.OrderByDescending(s => s.StartDate);
                    break;
                case "EndDate":
                    projects = projects.OrderBy(s => s.ActualCompletionDate);
                    break;
                case "EndDate_desc":
                    projects = projects.OrderByDescending(s => s.ActualCompletionDate);
                    break;
                default:
                    projects = projects.OrderBy(s => s.Name);
                    break;
            }

            return View(await projects.ToListAsync());

            


        }
    

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectNo,Name,Description,StartDate,GoalCompletionDate,ActualCompletionDate,Status")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectNo,Name,Description,StartDate,GoalCompletionDate,ActualCompletionDate,Status")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
