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
    public class DinnerFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DinnerFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DinnerFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.DinnerFood.ToListAsync());
        }

        // GET: DinnerFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinnerFood = await _context.DinnerFood
                .FirstOrDefaultAsync(m => m.DinnerFoodID == id);
            if (dinnerFood == null)
            {
                return NotFound();
            }

            return View(dinnerFood);
        }

        // GET: DinnerFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DinnerFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DinnerFoodID,DFName,DFCaloriePerOunce,DFGram,DFTotalCalorie,DFDbFoodID,DFUserID,DFDate")] DinnerFood dinnerFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dinnerFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dinnerFood);
        }

        // GET: DinnerFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinnerFood = await _context.DinnerFood.FindAsync(id);
            if (dinnerFood == null)
            {
                return NotFound();
            }
            return View(dinnerFood);
        }

        // POST: DinnerFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DinnerFoodID,DFName,DFCaloriePerOunce,DFGram,DFTotalCalorie,DFDbFoodID,DFUserID,DFDate")] DinnerFood dinnerFood)
        {
            if (id != dinnerFood.DinnerFoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dinnerFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DinnerFoodExists(dinnerFood.DinnerFoodID))
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
            return View(dinnerFood);
        }

        // GET: DinnerFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dinnerFood = await _context.DinnerFood
                .FirstOrDefaultAsync(m => m.DinnerFoodID == id);
            if (dinnerFood == null)
            {
                return NotFound();
            }

            return View(dinnerFood);
        }

        // POST: DinnerFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dinnerFood = await _context.DinnerFood.FindAsync(id);
            _context.DinnerFood.Remove(dinnerFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DinnerFoodExists(int id)
        {
            return _context.DinnerFood.Any(e => e.DinnerFoodID == id);
        }

        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ChosenFood = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            var PlannedFood = new DinnerFood
            {
                DFName = ChosenFood.Name,
                DFCaloriePerOunce = ChosenFood.CaloriePerOunce,
                DFDbFoodID = ChosenFood.FoodID
            };

            if (PlannedFood == null)
            {
                return NotFound();
            }

            return View(PlannedFood);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("DinnerFoodID,DFName,DFCaloriePerOunce,DFGram,DFTotalCalorie,DFDbFoodID,DFUserID,DFDate")] DinnerFood PlannedFood)
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
