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
            if(calc.Sex == true)
            {
                calc.CalculationResult = 10 * calc.BodyWeight+ 6.25 * calc.BodyHeight - 5 * calc.Age + 5;
            }
            else
            {
                calc.CalculationResult = 10 * calc.BodyWeight + 6.25 * calc.BodyHeight - 5 * calc.Age - 161;
            }

            return View(calc);
        }
    }
}
