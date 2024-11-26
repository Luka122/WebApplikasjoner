using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class NutritionController : Controller
{

    private readonly NutritionEntryDbContext _nutritionContext;

    public NutritionController(NutritionEntryDbContext nutritionContext)
    {
        _nutritionContext = nutritionContext;
    }

    public IActionResult Index()
    {

        List<NutritionEntry> entries = _nutritionContext.Entries.ToList();

        return View("NutritionTable", entries);
    }

    [HttpPost]
    public IActionResult Create(NutritionEntry entry)
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

            _nutritionContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // Error Response, Not implemented
        return Json(new { success = false, message = "Invalid data." });
    }
}