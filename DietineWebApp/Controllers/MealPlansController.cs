using DietineWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietineWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DietineWebApp.Controllers
{
    public class MealPlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MealPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index(string date)
        {
            if(date == null) date = DateTime.Now.ToString("yyyy-MM-dd");
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var mealPlan = new MealPlan()
            {
                BreakfastList = _context.BreakfastFood.Where(q => q.BFUserID == currentUserID),
                LunchList = _context.LunchFood.Where(q => q.LFUserID == currentUserID),
                DinnerList = _context.DinnerFood.Where(q => q.DFUserID == currentUserID),
                ActivityList = _context.TakenActivity.Where(q => q.TAUserID == currentUserID),
                Tanggal = date
            };

            return View(mealPlan);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ProcessAddition(MealPlan obj, string breakfast, string lunch, string dinner, string activity)
        {
            TempData["date"] = obj.Tanggal;

            if (!string.IsNullOrEmpty(breakfast))
            {
                return RedirectToAction("SeeList", "BreakfastFoods");
            }
            else if (!string.IsNullOrEmpty(lunch))
            {
                return RedirectToAction("SeeList", "LunchFoods");
            }
            else if (!string.IsNullOrEmpty(dinner))
            {
                return RedirectToAction("SeeList", "DinnerFoods");
            }
            else if (!string.IsNullOrEmpty(activity))
            {
                return RedirectToAction("SeeList", "TakenActivities");
            }
            else return RedirectToAction(nameof(Index), new { date = TempData["date"]});

        }

    }
}
