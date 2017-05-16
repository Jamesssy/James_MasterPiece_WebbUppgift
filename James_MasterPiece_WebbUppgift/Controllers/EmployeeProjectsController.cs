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
        public async Task<IActionResult> Index()
        {
            var masterPieceContext = _context.EmployeeProjects.Include(e => e.Employee).Include(e => e.Project);
            return View(await masterPieceContext.ToListAsync());
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id");
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProjects = await _context.EmployeeProjects.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeProjects == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", employeeProjects.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", employeeProjects.ProjectId);
            return View(employeeProjects);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,ProjectId")] EmployeeProjects employeeProjects)
        {
            if (id != employeeProjects.EmployeeId)
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
        public async Task<IActionResult> Delete(int? id)
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

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeProjects = await _context.EmployeeProjects.SingleOrDefaultAsync(m => m.EmployeeId == id);
            _context.EmployeeProjects.Remove(employeeProjects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeProjectsExists(int id)
        {
            return _context.EmployeeProjects.Any(e => e.EmployeeId == id);
        }
    }
}
