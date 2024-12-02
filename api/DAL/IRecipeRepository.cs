using Exam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.DAL
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<RecipeEntry>> GetAllRecipesAsync();
        Task<RecipeEntry?> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(RecipeEntry recipeEntry);
        Task UpdateRecipeAsync(RecipeEntry recipeEntry);
        Task DeleteRecipeAsync(int id);
    }
}
