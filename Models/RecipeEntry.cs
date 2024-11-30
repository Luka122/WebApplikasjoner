using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class RecipeEntry
    {
        public int RecipeId { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 240)]
        public int CookingTime { get; set; }

        [StringLength(200)]
        public string? ImageURL { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Ingredients { get; set; } = string.Empty; // Making it optional, similar to FoodGroup in NutritionEntry
    }
}
