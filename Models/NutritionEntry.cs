using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class NutritionEntry
    {
        public int NutritionId { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? FoodGroup { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
    }
}
