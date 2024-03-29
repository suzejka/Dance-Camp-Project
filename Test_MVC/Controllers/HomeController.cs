﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_MVC.Models;

namespace Test_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Today = DateOnly.FromDateTime(DateTime.Now);
            ViewBag.Tomorrow = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            return View();
        }

        public IActionResult OtherOptions()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult Operators()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}