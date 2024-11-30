using System.Collections.Generic;
using Exam.Models;

namespace Exam.DAL
{
    public interface IRecipeRepository
    {
        IEnumerable<RecipeEntry> GetAllRecipes();
        RecipeEntry? GetRecipeById(int id);
        void AddRecipe(RecipeEntry recipe);
        void UpdateRecipe(RecipeEntry recipe);
        void DeleteRecipe(int id);
        void Save();
    }
}
