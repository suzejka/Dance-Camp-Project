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
    public class MusicConsoleOperatorsController : Controller
    {
        private readonly CampDbContext _context;

        public MusicConsoleOperatorsController(CampDbContext context)
        {
            _context = context;
        }

        // GET: MusicConsoleOperators
        public async Task<IActionResult> Index()
        {
              return _context.MusicConsoleOperator != null ? 
                          View(await _context.MusicConsoleOperator.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.MusicConsoleOperator'  is null.");
        }

        // GET: MusicConsoleOperators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MusicConsoleOperator == null)
            {
                return NotFound();
            }

            var musicConsoleOperator = await _context.MusicConsoleOperator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicConsoleOperator == null)
            {
                return NotFound();
            }

            return View(musicConsoleOperator);
        }

        // GET: MusicConsoleOperators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicConsoleOperators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnEquipment,LicenceNumber,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] MusicConsoleOperator musicConsoleOperator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicConsoleOperator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicConsoleOperator);
        }

        // GET: MusicConsoleOperators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MusicConsoleOperator == null)
            {
                return NotFound();
            }

            var musicConsoleOperator = await _context.MusicConsoleOperator.FindAsync(id);
            if (musicConsoleOperator == null)
            {
                return NotFound();
            }
            return View(musicConsoleOperator);
        }

        // POST: MusicConsoleOperators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnEquipment,LicenceNumber,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] MusicConsoleOperator musicConsoleOperator)
        {
            if (id != musicConsoleOperator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicConsoleOperator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicConsoleOperatorExists(musicConsoleOperator.Id))
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
            return View(musicConsoleOperator);
        }

        // GET: MusicConsoleOperators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MusicConsoleOperator == null)
            {
                return NotFound();
            }

            var musicConsoleOperator = await _context.MusicConsoleOperator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicConsoleOperator == null)
            {
                return NotFound();
            }

            return View(musicConsoleOperator);
        }

        // POST: MusicConsoleOperators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MusicConsoleOperator == null)
            {
                return Problem("Entity set 'CampDbContext.MusicConsoleOperator'  is null.");
            }
            var musicConsoleOperator = await _context.MusicConsoleOperator.FindAsync(id);
            if (musicConsoleOperator != null)
            {
                _context.MusicConsoleOperator.Remove(musicConsoleOperator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicConsoleOperatorExists(int id)
        {
          return (_context.MusicConsoleOperator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
