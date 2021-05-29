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
    public class BreakfastFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BreakfastFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.BreakfastFood.ToListAsync());
        }

        // GET: BreakfastFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastFood = await _context.BreakfastFood
                .FirstOrDefaultAsync(m => m.BreakfastFoodID == id);
            if (breakfastFood == null)
            {
                return NotFound();
            }

            return View(breakfastFood);
        }

        // GET: BreakfastFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BreakfastFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreakfastFoodID,BFName,BFCaloriePerOunce,BFGram,BFTotalCalorie,BFDbFoodID,BFUserID,BFDate")] BreakfastFood breakfastFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfastFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakfastFood);
        }

        // GET: BreakfastFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastFood = await _context.BreakfastFood.FindAsync(id);
            if (breakfastFood == null)
            {
                return NotFound();
            }
            return View(breakfastFood);
        }

        // POST: BreakfastFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreakfastFoodID,BFName,BFCaloriePerOunce,BFGram,BFTotalCalorie,BFDbFoodID,BFUserID,BFDate")] BreakfastFood breakfastFood)
        {
            if (id != breakfastFood.BreakfastFoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfastFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastFoodExists(breakfastFood.BreakfastFoodID))
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
            return View(breakfastFood);
        }

        // GET: BreakfastFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastFood = await _context.BreakfastFood
                .FirstOrDefaultAsync(m => m.BreakfastFoodID == id);
            if (breakfastFood == null)
            {
                return NotFound();
            }

            return View(breakfastFood);
        }

        // POST: BreakfastFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfastFood = await _context.BreakfastFood.FindAsync(id);
            _context.BreakfastFood.Remove(breakfastFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastFoodExists(int id)
        {
            return _context.BreakfastFood.Any(e => e.BreakfastFoodID == id);
        }

        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ChosenFood = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            var PlannedFood = new BreakfastFood
            {
                BFName = ChosenFood.Name,
                BFCaloriePerOunce = ChosenFood.CaloriePerOunce,
                BFDbFoodID = ChosenFood.FoodID
            };

            if (PlannedFood == null)
            {
                return NotFound();
            }

            return View(PlannedFood);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("BreakfastFoodID,BFName,BFCaloriePerOunce,BFGram,BFTotalCalorie,BFDbFoodID,BFUserID,BFDate")] BreakfastFood PlannedFood)
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
