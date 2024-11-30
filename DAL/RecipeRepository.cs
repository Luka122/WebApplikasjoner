using System.Collections.Generic;
using System.Linq;
using Exam.Models;

namespace Exam.DAL
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RecipeEntry> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public RecipeEntry? GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
        }

        public void AddRecipe(RecipeEntry recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void UpdateRecipe(RecipeEntry recipe)
        {
            _context.Recipes.Update(recipe);
        }

        public void DeleteRecipe(int id)
        {
            var recipe = GetRecipeById(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
