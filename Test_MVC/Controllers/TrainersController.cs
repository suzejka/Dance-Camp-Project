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
    public class TrainersController : Controller
    {
        private readonly CampDbContext _context;

        public TrainersController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
              return _context.Trainer != null ? 
                          View(await _context.Trainer.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.Trainer'  is null.");
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        public async Task<IActionResult> AssignTraining(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }

        [HttpPost]
        public async Task<IActionResult> AssignTraining(Trainer trainer, Training training)
        {
            var room = _context.Room.Where(r => r.Id == 1).FirstOrDefault();
            if (trainer.CanTrainingBeAssigned())
            {
                Training t = new Training
                {
                    Name = "test",
                    Status = Status_Name.Scheduled,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMinutes(90),
                    Room = room
                };
                trainer.Trainings.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

            // GET: Trainers/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,ContactDetails,DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked")] Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerExists(trainer.Id))
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
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainer == null)
            {
                return Problem("Entity set 'CampDbContext.Trainer'  is null.");
            }
            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer != null)
            {
                _context.Trainer.Remove(trainer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
          return (_context.Trainer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
