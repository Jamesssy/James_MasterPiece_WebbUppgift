using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;
using James_MasterPiece_WebbUppgift.Context;
//using System.Data.Objects.SqlClient;
//using System.Data.Entity;

namespace James_MasterPiece_WebbUppgift.Controllers
{
    public class AddressesController : Controller
    {
        private readonly MasterPieceContext _context;

        public AddressesController()
        {
            _context = new MasterPieceContext();
        }

        // GET: Addresses
        public async Task<ViewResult> Index(string sortOrder, string searchString)

        {
            var address = _context.Address.Select(s => s).Include(a => a.Employee).Select(a => a);

            //using (var _context = new MasterPieceContext())

            ViewBag.StreetSortParm = String.IsNullOrEmpty(sortOrder) ? "street_desc" : "street";
            ViewBag.ZipCodeSortParm = sortOrder == "zipCode" ? "zipCode_desc" : "zipCode";
            ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "city";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            //ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "lastName";



            //SqlFunctions.StringConvert

            if (!String.IsNullOrEmpty(searchString))
            {
                address = address.Where(s => s.ZipCode.ToString().Contains(searchString)
                                       || s.Street.Contains(searchString)
                                       || s.City.Contains(searchString)
                                       || s.Employee.LastName.Contains(searchString)
                                       || s.Employee.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    address = address.OrderByDescending(s => s.Employee.FirstName);
                    break;


                case "street":
                    address = address.OrderBy(s => s.Street);
                    break;
                case "street_desc":
                    address = address.OrderByDescending(s => s.Street);
                    break;

                case "city":
                    address = address.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    address = address.OrderByDescending(s => s.City);
                    break;
                case "zipCode":
                    address = address.OrderBy(s => s.ZipCode);
                    break;
                case "zipCode_desc":
                    address = address.OrderByDescending(s => s.ZipCode);
                    break;
                default:
                    address = address.OrderBy(s => s.Employee.FirstName);
                    break;
            }

            return View(await address.ToListAsync());




        }
        //public async Task<IActionResult> Index()
        //{
        //    var masterPieceContext = _context.Address.Include(a => a.Employee);
        //    return View(await masterPieceContext.ToListAsync());
        //}

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,ZipCode,City,EmployeeId")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address.SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", address.EmployeeId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Street,ZipCode,City,EmployeeId")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Address.SingleOrDefaultAsync(m => m.Id == id);
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
