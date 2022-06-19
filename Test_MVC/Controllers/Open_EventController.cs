using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_MVC.Data;
using Test_MVC.Models;

namespace Test_MVC.Controllers
{
    public class Open_EventController : Controller
    {
        private readonly CampDbContext _context;

        public Open_EventController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Open_Event
        public async Task<IActionResult> Index()
        {
              return _context.Open_Events != null ? 
                          View(await _context.Open_Events.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.Open_Events'  is null.");
        }

        // GET: Open_Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Open_Events == null)
            {
                return NotFound();
            }

            var open_Event = await _context.Open_Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (open_Event == null)
            {
                return NotFound();
            }

            return View(open_Event);
        }

        // GET: Open_Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Open_Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetAddress,MaxAmountOfPeople,Id,Name,Status")] Open_Event open_Event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(open_Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(open_Event);
        }

        // GET: Open_Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Open_Events == null)
            {
                return NotFound();
            }

            var open_Event = await _context.Open_Events.FindAsync(id);
            if (open_Event == null)
            {
                return NotFound();
            }
            return View(open_Event);
        }

        // POST: Open_Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreetAddress,MaxAmountOfPeople,Id,Name,Status")] Open_Event open_Event)
        {
            if (id != open_Event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(open_Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Open_EventExists(open_Event.Id))
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
            return View(open_Event);
        }

        // GET: Open_Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Open_Events == null)
            {
                return NotFound();
            }

            var open_Event = await _context.Open_Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (open_Event == null)
            {
                return NotFound();
            }

            return View(open_Event);
        }

        // POST: Open_Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Open_Events == null)
            {
                return Problem("Entity set 'CampDbContext.Open_Events'  is null.");
            }
            var open_Event = await _context.Open_Events.FindAsync(id);
            if (open_Event != null)
            {
                _context.Open_Events.Remove(open_Event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Open_EventExists(int id)
        {
          return (_context.Open_Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
