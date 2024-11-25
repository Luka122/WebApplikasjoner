using System;

namespace Exam.Models
{
    public class NutritionEntry
    {
        public int NutritionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? FoodGroup { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double? Protein { get; set; }
        public double? Fat { get; set; }
        public double? Carbohydrates { get; set; }
    }
}
