using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Collections.Generic;

namespace Exam.Controllers;

public class NutritionController : Controller
{
    private readonly NutritionDbContext _context;

    public NutritionController(NutritionDbContext context)
    {
        _context = context;
    }

    public IActionResult Nutrition()
    {
        var nutritionData = _context.Items.ToList();
        return View(nutritionData);
    }
}