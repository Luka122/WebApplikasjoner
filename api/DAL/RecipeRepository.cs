using Exam.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.DAL
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(RecipeDbContext context, ILogger<RecipeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RecipeEntry>> GetAllRecipesAsync()
        {
            try
            {
                return await _context.Recipes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all recipes");
                throw;
            }
        }

        public async Task<RecipeEntry?> GetRecipeByIdAsync(int id)
        {
            try
            {
                return await _context!.Recipes.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching recipe with ID: {id}");
                throw;
            }
        }

        public async Task AddRecipeAsync(RecipeEntry recipeEntry)
        {
            try
            {
                await _context.Recipes.AddAsync(recipeEntry);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Recipe '{recipeEntry.Name}' added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a recipe");
                throw;
            }
        }

        public async Task UpdateRecipeAsync(RecipeEntry recipeEntry)
        {
            try
            {
                _context.Recipes.Update(recipeEntry);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Recipe with ID {recipeEntry.RecipeId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating recipe with ID: {recipeEntry.RecipeId}");
                throw;
            }
        }

        public async Task DeleteRecipeAsync(int id)
        {
            try
            {
                var recipe = await _context.Recipes.FindAsync(id);
                if (recipe != null)
                {
                    _context.Recipes.Remove(recipe);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Recipe with ID {id} deleted successfully.");
                }
                else
                {
                    _logger.LogWarning($"Recipe with ID {id} was not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting recipe with ID: {id}");
                throw;
            }
        }
    }
}
