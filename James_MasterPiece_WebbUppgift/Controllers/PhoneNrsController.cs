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
    public class PhoneNrsController : Controller
    {
        private readonly MasterPieceContext _context;

        public PhoneNrsController()
        {
            _context = new MasterPieceContext();
        }

        // GET: PhoneNrs
        public async Task<IActionResult> Index()
        {
            var masterPieceContext = _context.PhoneNr.Include(p => p.Employee);
            return View(await masterPieceContext.ToListAsync());
        }

        // GET: PhoneNrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNr = await _context.PhoneNr
                .Include(p => p.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNr == null)
            {
                return NotFound();
            }

            return View(phoneNr);
        }

        // GET: PhoneNrs/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName");
            return View();
        }

        // POST: PhoneNrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MainPhoneNr,AltPhoneNr1,AltPhoneNr2,EmployeeId")] PhoneNr phoneNr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNr);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", phoneNr.EmployeeId);
            return View(phoneNr);
        }

        // GET: PhoneNrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNr = await _context.PhoneNr.SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNr == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", phoneNr.EmployeeId);
            return View(phoneNr);
        }

        // POST: PhoneNrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MainPhoneNr,AltPhoneNr1,AltPhoneNr2,EmployeeId")] PhoneNr phoneNr)
        {
            if (id != phoneNr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNrExists(phoneNr.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", phoneNr.EmployeeId);
            return View(phoneNr);
        }

        // GET: PhoneNrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNr = await _context.PhoneNr
                .Include(p => p.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNr == null)
            {
                return NotFound();
            }

            return View(phoneNr);
        }

        // POST: PhoneNrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneNr = await _context.PhoneNr.SingleOrDefaultAsync(m => m.Id == id);
            _context.PhoneNr.Remove(phoneNr);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PhoneNrExists(int id)
        {
            return _context.PhoneNr.Any(e => e.Id == id);
        }
    }
}
