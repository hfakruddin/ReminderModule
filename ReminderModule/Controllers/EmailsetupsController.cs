using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReminderModule.Data;
using ReminderModule.Data.Models;

namespace ReminderModule.Controllers
{
    public class EmailsetupsController : Controller
    {
        private readonly ReminderModuleContext _context;

        public EmailsetupsController(ReminderModuleContext context)
        {
            _context = context;
        }

        // GET: Emailsetups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emailsetup.ToListAsync());
        }

        // GET: Emailsetups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailsetup = await _context.Emailsetup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailsetup == null)
            {
                return NotFound();
            }

            return View(emailsetup);
        }

        // GET: Emailsetups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emailsetups/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Emailsetup emailsetup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailsetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailsetup);
        }

        // GET: Emailsetups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var savestatus = TempData["savestatus"];
            if (savestatus != null)
            {
                if (savestatus.ToString() == "OK")
                {
                    ViewBag.savestatus = "OK";
                }
            }
            
            
            var emailsetup = await _context.Emailsetup.FindAsync(id);
            if (emailsetup == null)
            {
                return NotFound();
            }
            return View(emailsetup);
        }

        // POST: Emailsetups/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Edit(int id, Emailsetup emailsetup)
        {
            if (id != emailsetup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailsetup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailsetupExists(emailsetup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["savestatus"] = "OK";
                TempData.Keep();
                return RedirectToAction(nameof(Edit), id);
            }
            return View(emailsetup);
        }

        // GET: Emailsetups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailsetup = await _context.Emailsetup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailsetup == null)
            {
                return NotFound();
            }

            return View(emailsetup);
        }

        // POST: Emailsetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailsetup = await _context.Emailsetup.FindAsync(id);
            if (emailsetup != null)
            {
                _context.Emailsetup.Remove(emailsetup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailsetupExists(int id)
        {
            return _context.Emailsetup.Any(e => e.Id == id);
        }
    }
}
