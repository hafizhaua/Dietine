using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article1()
        {
            return View();
        }
        public IActionResult Article2()
        {
            return View();
        }
        public IActionResult Article3()
        {
            return View();
        }
        public IActionResult Article4()
        {
            return View();
        }
        public IActionResult Article5()
        {
            return View();
        }
    }
}
