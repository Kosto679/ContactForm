using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactForm.Data;
using ContactForm.Models;

namespace ContactForm.Controllers
{
    public class CustomersController : Controller
    {
        private readonly FormContext _context;

        public CustomersController(FormContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return _context.Persondets != null ? 
                          View(await _context.Persondets.ToListAsync()) :
                          Problem("Entity set 'FormContext.Persondets'  is null.");
        }

        // GET: Customers/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persondets == null)
            {
                return NotFound();
            }

            var customer = await _context.Persondets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,HomePhone,MobilePhone,WorkPhone")] Customer customer)
        {


            if (ModelState.IsValid)
            {

                var phoneNumber = new PhoneContact
                {
                    CustomerId = customer.Id,
                    HomePhone = customer.HomePhone,
                    MobilePhone = customer.MobilePhone,
                    WorkPhone = customer.WorkPhone
                };

                _context.Add(customer);
                _context.Phonedets.Add(phoneNumber);
                await _context.SaveChangesAsync();
                TempData["success"] = "Customer created successfully";
                return RedirectToAction(nameof(Index));
                
            }
            return View(customer);
        }

        // GET: Customers/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persondets == null)
            {
                return NotFound();
            }

            var customer = await _context.Persondets.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,HomePhone,MobilePhone,WorkPhone")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var phoneNumber = new PhoneContact
                    {
                        CustomerId = customer.Id,
                        HomePhone = customer.HomePhone,
                        MobilePhone = customer.MobilePhone,
                        WorkPhone = customer.WorkPhone
                    };
                    _context.Update(customer);
                    _context.Phonedets.Update(phoneNumber);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Customer info edited successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persondets == null)
            {
                return NotFound();
            }

            var customer = await _context.Persondets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persondets == null)
            {
                return Problem("Entity set 'FormContext.Persondets'  is null.");
            }
            var customer = await _context.Persondets.FindAsync(id);
            var phoneNumber = await _context.Phonedets.FindAsync(id);
            if (customer != null)
            {
                _context.Persondets.Remove(customer);
                //_context.Phonedets.Remove(phoneNumber);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Customer deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Persondets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
