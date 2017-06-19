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
    public class EmployeesController : Controller
    {
        private readonly MasterPieceContext _context;

        public EmployeesController(MasterPieceContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<ViewResult> Index(string sortOrder, string searchString)
            
        {
            //using (var _context = new MasterPieceContext())

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "lastName";
            ViewBag.DateSortParm = sortOrder == "DateOfBirth" ? "DateOfBirth_desc" : "DateOfBirth";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            ViewBag.EmployedDateSortParm = sortOrder == "EmployedSince" ? "EmployedSince_desc" : "EmployedSince";


            var employees = from s in _context.Employee
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;
                case "lastName":
                    employees = employees.OrderBy(s => s.LastName);
                    break;
                case "lastName_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                
                case "DateOfBirth":
                    employees = employees.OrderBy(s => s.DateOfBirth);
                    break;
                case "DateOfBirth_desc":
                    employees = employees.OrderByDescending(s => s.DateOfBirth);
                    break;
                
                case "EmployedSince":
                    employees = employees.OrderBy(s => s.EmployedSince);
                    break;
                case "EmployedSince_desc":
                    employees = employees.OrderByDescending(s => s.EmployedSince);
                    break;
                default:
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
            }
            return View(await employees.ToListAsync());
            



        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,EmployedSince")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,EmployedSince")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //Support support = db.Support.Find(id);
            //support.Servers.Clear();
            //db.Support.Remove(support);
            //db.SaveChanges();

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
