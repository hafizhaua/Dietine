using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietine.Models;

namespace Dietine.Controllers
{
    public class MakananController : Controller
    {
        // dummy data for testing
        private List<MakananModel> databaseMakanan = new List<MakananModel>()
        {
            new MakananModel(){ Nama = "Nasi putih", KaloriPerOns = 100},
            new MakananModel(){ Nama = "Nasi goreng", KaloriPerOns = 300},
            new MakananModel(){ Nama = "Nasi lemak", KaloriPerOns = 200},
        };
        public IActionResult Index()
        {
            IEnumerable<MakananModel> objList = databaseMakanan;
            return View(objList);
        }
    }
}
