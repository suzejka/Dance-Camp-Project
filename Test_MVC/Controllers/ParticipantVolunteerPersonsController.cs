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
    public class ParticipantVolunteerPersonsController : Controller
    {
        private readonly CampDbContext _context;

        public ParticipantVolunteerPersonsController(CampDbContext context)
        {
            _context = context;
        }

        // GET: ParticipantVolunteerPersons
        public async Task<IActionResult> Index()
        {
              return _context.ParticipantVolunteerPerson != null ? 
                          View(await _context.ParticipantVolunteerPerson.ToListAsync()) :
                          Problem("Entity set 'CampDbContext.ParticipantVolunteerPerson'  is null.");
        }

        // GET: ParticipantVolunteerPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParticipantVolunteerPerson == null)
            {
                return NotFound();
            }

            var participantVolunteerPerson = await _context.ParticipantVolunteerPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participantVolunteerPerson == null)
            {
                return NotFound();
            }

            return View(participantVolunteerPerson);
        }

        // GET: ParticipantVolunteerPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParticipantVolunteerPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParticipantVolunteerPerson participantVolunteerPerson)
        {
            participantVolunteerPerson.personTypes.Add(PersonType.Participant);

            if (ModelState.IsValid)
            {
                _context.Add(participantVolunteerPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participantVolunteerPerson);
        }

        // GET: ParticipantVolunteerPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParticipantVolunteerPerson == null)
            {
                return NotFound();
            }

            var participantVolunteerPerson = await _context.ParticipantVolunteerPerson.FindAsync(id);
            if (participantVolunteerPerson == null)
            {
                return NotFound();
            }
            return View(participantVolunteerPerson);
        }

        // POST: ParticipantVolunteerPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DormitoryNumber,RoomNumber,ArrivalDate,DepartureDate,AmountOfHoursWorked,Id,Name,Surname,ContactDetails")] ParticipantVolunteerPerson participantVolunteerPerson)
        {
            if (id != participantVolunteerPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participantVolunteerPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantVolunteerPersonExists(participantVolunteerPerson.Id))
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
            return View(participantVolunteerPerson);
        }

        // GET: ParticipantVolunteerPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParticipantVolunteerPerson == null)
            {
                return NotFound();
            }

            var participantVolunteerPerson = await _context.ParticipantVolunteerPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participantVolunteerPerson == null)
            {
                return NotFound();
            }

            return View(participantVolunteerPerson);
        }

        // POST: ParticipantVolunteerPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParticipantVolunteerPerson == null)
            {
                return Problem("Entity set 'CampDbContext.ParticipantVolunteerPerson'  is null.");
            }
            var participantVolunteerPerson = await _context.ParticipantVolunteerPerson.FindAsync(id);
            if (participantVolunteerPerson != null)
            {
                _context.ParticipantVolunteerPerson.Remove(participantVolunteerPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantVolunteerPersonExists(int id)
        {
          return (_context.ParticipantVolunteerPerson?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
