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
    public class SponsorOpenEventsController : Controller
    {
        private readonly CampDbContext _context;

        List<SelectListItem> sponsorsSelect = new();

        public SponsorOpenEventsController(CampDbContext context)
        {
            _context = context;
        }

        // GET: SponsorOpenEvents
        public async Task<IActionResult> Index()
        {
              return _context.SponsorOpenEvents != null ? 
                          View(await _context.SponsorOpenEvents.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.SponsorOpenEvents'  is null.");
        }

        // GET: SponsorOpenEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SponsorOpenEvents == null)
            {
                return NotFound();
            }

            var sponsorOpenEvent = await _context.SponsorOpenEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponsorOpenEvent == null)
            {
                return NotFound();
            }

            return View(sponsorOpenEvent);
        }

        // GET: SponsorOpenEvents/Create
        public IActionResult Create()
        {
            var sponsors = _context.Sponsor.ToList();

            

            foreach (var s in sponsors)
            {
                sponsorsSelect.Add(new SelectListItem() { Text = s.Name, Value = s.Id.ToString()});
            }

            ViewBag.Sponsors = sponsorsSelect;

            return View();
        }

        // POST: SponsorOpenEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SponsorOpenEvent sponsorOpenEvent)
        {
            ViewBag.Sponsors = sponsorsSelect;

            var sponsorId = Convert.ToInt32(ViewData.ModelState["Sponsor.Id"].RawValue);
            var eventId = Convert.ToInt32(ViewData.ModelState["OpenEvent.Id"].RawValue);

            //sponsorOpenEvent.Sponsor = _context.Sponsor.Where(s => s.Id == sponsorId).FirstOrDefault();
            //sponsorOpenEvent.OpenEvent = _context.Open_Events.Where(o => o.Id == eventId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                _context.Add(sponsorOpenEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsorOpenEvent);
        }

        // GET: SponsorOpenEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SponsorOpenEvents == null)
            {
                return NotFound();
            }

            var sponsorOpenEvent = await _context.SponsorOpenEvents.FindAsync(id);
            if (sponsorOpenEvent == null)
            {
                return NotFound();
            }
            return View(sponsorOpenEvent);
        }

        // POST: SponsorOpenEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AmountReceivedFromSponsors")] SponsorOpenEvent sponsorOpenEvent)
        {
            if (id != sponsorOpenEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsorOpenEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorOpenEventExists(sponsorOpenEvent.Id))
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
            return View(sponsorOpenEvent);
        }

        // GET: SponsorOpenEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SponsorOpenEvents == null)
            {
                return NotFound();
            }

            var sponsorOpenEvent = await _context.SponsorOpenEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponsorOpenEvent == null)
            {
                return NotFound();
            }

            return View(sponsorOpenEvent);
        }

        // POST: SponsorOpenEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SponsorOpenEvents == null)
            {
                return Problem("Entity set 'CampDbContext.SponsorOpenEvents'  is null.");
            }
            var sponsorOpenEvent = await _context.SponsorOpenEvents.FindAsync(id);
            if (sponsorOpenEvent != null)
            {
                _context.SponsorOpenEvents.Remove(sponsorOpenEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorOpenEventExists(int id)
        {
          return (_context.SponsorOpenEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
