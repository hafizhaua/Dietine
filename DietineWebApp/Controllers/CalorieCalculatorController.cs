using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietineWebApp.Models;

namespace DietineWebApp.Controllers
{
    public class CalorieCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CalorieCalculator calc)
        {
            return View(calc);
        }
    }
}
