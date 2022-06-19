﻿using System;
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
    public class SponsorsController : Controller
    {
        private readonly CampDbContext _context;

        public SponsorsController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Sponsors
        public async Task<IActionResult> Index()
        {
              return _context.Sponsor != null ? 
                          View(await _context.Sponsor.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.Sponsor'  is null.");
        }

        // GET: Sponsors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sponsor == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor.Include(e => e.SponsorOpenEvents).ThenInclude(o => o.OpenEvent)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sponsor == null)
            {
                return NotFound();
            }

            ViewBag.SponsorOpenEvents = sponsor.SponsorOpenEvents.ToList();
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sponsor == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Sponsor sponsor)
        {
            if (id != sponsor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.Id))
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
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sponsor == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sponsor == null)
            {
                return Problem("Entity set 'CampDbContext.Sponsor'  is null.");
            }
            var sponsor = await _context.Sponsor.FindAsync(id);
            if (sponsor != null)
            {
                _context.Sponsor.Remove(sponsor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorExists(int id)
        {
          return (_context.Sponsor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
