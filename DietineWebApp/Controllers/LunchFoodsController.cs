using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DietineWebApp.Data;
using DietineWebApp.Models;

namespace DietineWebApp.Controllers
{
    public class LunchFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LunchFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LunchFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.LunchFood.ToListAsync());
        }

        // GET: LunchFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchFood = await _context.LunchFood
                .FirstOrDefaultAsync(m => m.LunchFoodID == id);
            if (lunchFood == null)
            {
                return NotFound();
            }

            return View(lunchFood);
        }

        // GET: LunchFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LunchFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LunchFoodID,LFName,LFCaloriePerOunce,LFGram,LFTotalCalorie,LFDbFoodID,LFUserID,LFDate")] LunchFood lunchFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lunchFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lunchFood);
        }

        // GET: LunchFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchFood = await _context.LunchFood.FindAsync(id);
            if (lunchFood == null)
            {
                return NotFound();
            }
            return View(lunchFood);
        }

        // POST: LunchFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LunchFoodID,LFName,LFCaloriePerOunce,LFGram,LFTotalCalorie,LFDbFoodID,LFUserID,LFDate")] LunchFood lunchFood)
        {
            if (id != lunchFood.LunchFoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lunchFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LunchFoodExists(lunchFood.LunchFoodID))
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
            return View(lunchFood);
        }

        // GET: LunchFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchFood = await _context.LunchFood
                .FirstOrDefaultAsync(m => m.LunchFoodID == id);
            if (lunchFood == null)
            {
                return NotFound();
            }

            return View(lunchFood);
        }

        // POST: LunchFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lunchFood = await _context.LunchFood.FindAsync(id);
            _context.LunchFood.Remove(lunchFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LunchFoodExists(int id)
        {
            return _context.LunchFood.Any(e => e.LunchFoodID == id);
        }
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ChosenFood = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            var PlannedFood = new LunchFood
            {
                LFName = ChosenFood.Name,
                LFCaloriePerOunce = ChosenFood.CaloriePerOunce,
                LFDbFoodID = ChosenFood.FoodID
            };

            if (PlannedFood == null)
            {
                return NotFound();
            }

            return View(PlannedFood);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("LunchFoodID,LFName,LFCaloriePerOunce,LFGram,LFTotalCalorie,LFDbFoodID,LFUserID,LFDate")] LunchFood PlannedFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(PlannedFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(PlannedFood);
        }

        public IActionResult AddNewFood()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewFood([Bind("FoodID,Name,CaloriePerOunce")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Food.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SeeList));
            }
            return View(food);
        }
        public async Task<IActionResult> SeeList()
        {
            return View(await _context.Food.ToListAsync());
        }
    }
}
