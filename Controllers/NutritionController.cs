using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Collections.Generic;

public class NutritionController : Controller
{

    private readonly NutritionEntryDbContext _nutritionContext;

    public NutritionController(NutritionEntryDbContext nutritionContext)
    {
        _nutritionContext = nutritionContext;
    }

    public IActionResult Nutrition()
    {

        List<NutritionEntry> entries = _nutritionContext.Entries.ToList();

        return View(entries);
    }
}