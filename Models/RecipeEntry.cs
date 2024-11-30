namespace Exam.Models
{
    public class RecipeEntry
    {
        public int RecipeId { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty; // Recipe Name
        public string Description { get; set; } = string.Empty; // Recipe Description
        public int CookingTime { get; set; } // Cooking Time in minutes
        public string ImageURL { get; set; } = string.Empty; // Path to recipe image
        public string Ingredients { get; set; } = string.Empty; // List of ingredients
    }
}
