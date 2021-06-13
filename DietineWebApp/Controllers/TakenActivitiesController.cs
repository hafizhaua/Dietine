using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DietineWebApp.Data;
using DietineWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DietineWebApp.Controllers
{
    public class TakenActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TakenActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[Authorize]
        //// GET: TakenActivities
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TakenActivity.ToListAsync());
        //}

        //[Authorize]
        //// GET: TakenActivities/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var takenActivity = await _context.TakenActivity
        //        .FirstOrDefaultAsync(m => m.TakenActivityID == id);
        //    if (takenActivity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(takenActivity);
        //}

        //[Authorize]
        //// GET: TakenActivities/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: TakenActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TakenActivityID,TAName,TACalorieBurnedPerMinute,TAMinute,TATotalCaloriBurned,TADate,TADbID,TAUserID")] TakenActivity takenActivity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(takenActivity);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index), "MealPlans");
        //    }
        //    return View(takenActivity);
        //}

        // GET: TakenActivities/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClaimsPrincipal currentUser = User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var takenActivity = await _context.TakenActivity
                .FirstOrDefaultAsync(m => m.TakenActivityID == id && m.TAUserID == currentUserID);

            if (takenActivity == null)
            {
                return NotFound();
            }
            return View(takenActivity);
        }

        // POST: TakenActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TakenActivityID,TAName,TACalorieBurnedPerMinute,TAMinute,TATotalCaloriBurned,TADate,TADbID,TAUserID")] TakenActivity takenActivity)
        {
            if (id != takenActivity.TakenActivityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string date = takenActivity.TADate;
                try
                {
                    _context.Update(takenActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakenActivityExists(takenActivity.TakenActivityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "MealPlans", new { date = date });
            }
            return View(takenActivity);
        }

        // GET: TakenActivities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClaimsPrincipal currentUser = User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var takenActivity = await _context.TakenActivity
                .FirstOrDefaultAsync(m => m.TakenActivityID == id && m.TAUserID == currentUserID);

            if (takenActivity == null)
            {
                return NotFound();
            }

            return View(takenActivity);
        }

        // POST: TakenActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var takenActivity = await _context.TakenActivity.FindAsync(id);
            _context.TakenActivity.Remove(takenActivity);
            string date = takenActivity.TADate;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "MealPlans", new { date = date });
        }

        private bool TakenActivityExists(int id)
        {
            return _context.TakenActivity.Any(e => e.TakenActivityID == id);
        }

        [Authorize]
        public async Task<IActionResult> Add(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ChosenActivity = await _context.Activity.FirstOrDefaultAsync(m => m.ActivityID == id);

            var PlannedActivity = new TakenActivity
            {
                TAName = ChosenActivity.ActivityName,
                TACalorieBurnedPerMinute = ChosenActivity.CalorieBurnedPerMinute,
                TADbID = ChosenActivity.ActivityID
            };

            if (TempData.ContainsKey("date"))
            {
                DateTime tanggalDT = DateTime.Parse(TempData["date"].ToString());
                PlannedActivity.TADate = tanggalDT.ToString("yyyy-MM-dd");
            }
            else PlannedActivity.TADate = DateTime.Now.ToString("yyyy-MM-dd");

            if (PlannedActivity == null)
            {
                return NotFound();
            }

            return View(PlannedActivity);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("TakenActivityID,TAName,TACalorieBurnedPerMinute,TAMinute,TATotalCaloriBurned,TADate,TADbID,TAUserID")] TakenActivity takenActivity)
        {
            if (ModelState.IsValid)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                takenActivity.TAUserID = currentUserID;

                string date = takenActivity.TADate;
                _context.Add(takenActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "MealPlans", new { date = date });
            }
            return View(takenActivity);
        }

        [Authorize]
        public IActionResult AddNewActivity()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewActivity([Bind("ActivityID,ActivityName,CalorieBurnedPerMinute")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activity.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SeeList));
            }
            return View(activity);
        }

        [Authorize]
        public async Task<IActionResult> SeeList()
        {
            return View(await _context.Activity.ToListAsync());
        }
    }
}
