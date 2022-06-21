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
    public class Close_EventController : Controller
    {
        private readonly CampDbContext _context;

        public Close_EventController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Close_Event
        public async Task<IActionResult> Index()
        {
              return _context.Close_Event != null ? 
                          View(await _context.Close_Event.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.Close_Event'  is null.");
        }

        // GET: Close_Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Close_Event == null)
            {
                return NotFound();
            }

            var close_Event = await _context.Close_Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (close_Event == null)
            {
                return NotFound();
            }

            return View(close_Event);
        }

        // GET: Close_Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Close_Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Close_Event close_Event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(close_Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(close_Event);
        }

        // GET: Close_Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Close_Event == null)
            {
                return NotFound();
            }

            var close_Event = await _context.Close_Event.FindAsync(id);
            if (close_Event == null)
            {
                return NotFound();
            }
            return View(close_Event);
        }

        // POST: Close_Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] Close_Event close_Event)
        {
            if (id != close_Event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(close_Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Close_EventExists(close_Event.Id))
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
            return View(close_Event);
        }

        // GET: Close_Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Close_Event == null)
            {
                return NotFound();
            }

            var close_Event = await _context.Close_Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (close_Event == null)
            {
                return NotFound();
            }

            return View(close_Event);
        }

        // POST: Close_Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Close_Event == null)
            {
                return Problem("Entity set 'CampDbContext.Close_Event'  is null.");
            }
            var close_Event = await _context.Close_Event.FindAsync(id);
            if (close_Event != null)
            {
                _context.Close_Event.Remove(close_Event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Close_EventExists(int id)
        {
          return (_context.Close_Event?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
