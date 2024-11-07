using System;

namespace Exam.Models
{
    public class NutritionModel
    {
    public int Id { get; set; }        
    public string? FoodItem { get; set; }
    public int Calories { get; set; }
    public double? Protein { get; set; }
    public double? Fat { get; set; }
    public double? Carbohydrates { get; set; }
    }
}
