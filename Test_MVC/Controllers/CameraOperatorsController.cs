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
    public class CameraOperatorsController : Controller
    {
        private readonly CampDbContext _context;

        public CameraOperatorsController(CampDbContext context)
        {
            _context = context;
        }

        // GET: CameraOperators
        public async Task<IActionResult> Index()
        {
              return _context.CameraOperator != null ? 
                          View(await _context.CameraOperator.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.CameraOperator'  is null.");
        }

        // GET: CameraOperators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CameraOperator == null)
            {
                return NotFound();
            }

            var cameraOperator = await _context.CameraOperator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraOperator == null)
            {
                return NotFound();
            }

            return View(cameraOperator);
        }

        // GET: CameraOperators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CameraOperators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicenceNumber,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] CameraOperator cameraOperator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cameraOperator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cameraOperator);
        }

        // GET: CameraOperators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CameraOperator == null)
            {
                return NotFound();
            }

            var cameraOperator = await _context.CameraOperator.FindAsync(id);
            if (cameraOperator == null)
            {
                return NotFound();
            }
            return View(cameraOperator);
        }

        // POST: CameraOperators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenceNumber,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] CameraOperator cameraOperator)
        {
            if (id != cameraOperator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cameraOperator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraOperatorExists(cameraOperator.Id))
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
            return View(cameraOperator);
        }

        // GET: CameraOperators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CameraOperator == null)
            {
                return NotFound();
            }

            var cameraOperator = await _context.CameraOperator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraOperator == null)
            {
                return NotFound();
            }

            return View(cameraOperator);
        }

        // POST: CameraOperators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CameraOperator == null)
            {
                return Problem("Entity set 'CampDbContext.CameraOperator'  is null.");
            }
            var cameraOperator = await _context.CameraOperator.FindAsync(id);
            if (cameraOperator != null)
            {
                _context.CameraOperator.Remove(cameraOperator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CameraOperatorExists(int id)
        {
          return (_context.CameraOperator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
