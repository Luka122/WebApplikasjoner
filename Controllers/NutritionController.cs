using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Collections.Generic;

public class NutritionController : Controller
{
    public IActionResult Nutrition()
    {
        // test data
        var nutritionData = new List<NutritionModel> 
        {
            new NutritionModel { FoodItem = "Apple", Calories = 95, Protein = 0.5, Fat = 0.3, Carbohydrates = 25 }, //example 
            new NutritionModel { FoodItem = "Chicken Breast", Calories = 165, Protein = 31, Fat = 3.6, Carbohydrates = 0 }, //example 

        };

        return View(nutritionData);
    }
}