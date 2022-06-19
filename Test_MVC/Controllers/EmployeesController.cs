﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_MVC.Data;

namespace Test_MVC.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly CampDbContext _context;

        public EmployeesController(CampDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public ActionResult Index()
        {
            ViewData["Trainers"] = _context.Trainer.ToList();
            ViewData["Operators"] = _context.Operator.ToList();
            ViewData["Organisers"] = _context.Organiser.ToList();
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
