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
    public class OrganisersController : Controller
    {
        private readonly CampDbContext _context;

        public OrganisersController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Organisers
        public async Task<IActionResult> Index()
        {
              return _context.Organiser != null ? 
                          View(await _context.Organiser.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.Organiser'  is null.");
        }

        // GET: Organisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Organiser == null)
            {
                return NotFound();
            }

            var organiser = await _context.Organiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organiser == null)
            {
                return NotFound();
            }

            return View(organiser);
        }

        // GET: Organisers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkSector,Id,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] Organiser organiser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organiser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organiser);
        }

        // GET: Organisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organiser == null)
            {
                return NotFound();
            }

            var organiser = await _context.Organiser.FindAsync(id);
            if (organiser == null)
            {
                return NotFound();
            }
            return View(organiser);
        }

        // POST: Organisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkSector,Id,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] Organiser organiser)
        {
            if (id != organiser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganiserExists(organiser.Id))
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
            return View(organiser);
        }

        // GET: Organisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organiser == null)
            {
                return NotFound();
            }

            var organiser = await _context.Organiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organiser == null)
            {
                return NotFound();
            }

            return View(organiser);
        }

        // POST: Organisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organiser == null)
            {
                return Problem("Entity set 'CampDbContext.Organiser'  is null.");
            }
            var organiser = await _context.Organiser.FindAsync(id);
            if (organiser != null)
            {
                _context.Organiser.Remove(organiser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganiserExists(int id)
        {
          return (_context.Organiser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
