using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; 

public class NutritionController : Controller
{
    private readonly NutritionEntryDbContext _nutritionContext;

    public NutritionController(NutritionEntryDbContext nutritionContext)
    {
        _nutritionContext = nutritionContext;
    }
    
    public async Task<IActionResult> Index()
    {
        List<NutritionEntry> entries = await _nutritionContext.Entries.ToListAsync();
        return View("NutritionTable", entries);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            var newEntry = new NutritionEntry
            {
                Name = entry.Name,
                FoodGroup = entry.FoodGroup,
                Calories = entry.Calories,
                Protein = entry.Protein,
                Fat = entry.Fat,
                Carbohydrates = entry.Carbohydrates
            };

            _nutritionContext.Entries.Add(newEntry);
            await _nutritionContext.SaveChangesAsync(); 

            return RedirectToAction("Index");
        }

        // Error Response, not implemented
        return Json(new { success = false, message = "Invalid data." });
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _nutritionContext.Entries.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _nutritionContext.Entries.Remove(item);
        await _nutritionContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var item = await _nutritionContext.Entries.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }


    [HttpPost]
    public async Task<IActionResult> Update(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            _nutritionContext.Entries.Update(entry);
            await _nutritionContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(entry);
    }
}