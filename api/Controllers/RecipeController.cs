using Microsoft.AspNetCore.Mvc;
using Exam.DAL;
using Exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeRepository recipeRepository, ILogger<RecipeController> logger)
        {
            _recipeRepository = recipeRepository;
            _logger = logger;
        }

        // GET: Recipe/Index
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                var recipes = await _recipeRepository.GetAllRecipesAsync();
                return View(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the recipes.");
                TempData["ErrorMessage"] = "Unable to fetch recipes. Please try again later.";
                return View("Error");
            }
        }

        // GET: Recipe/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeEntry recipeEntry)
        {
            if (!ModelState.IsValid)
            {
                return View(recipeEntry);
            }

            try
            {
                await _recipeRepository.AddRecipeAsync(recipeEntry);
                TempData["SuccessMessage"] = "Recipe added successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the recipe.");
                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                return View(recipeEntry);
            }
        }

        // GET: Recipe/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecipeEntry recipeEntry)
        {
            if (!ModelState.IsValid)
            {
                return View(recipeEntry);
            }

            try
            {
                await _recipeRepository.UpdateRecipeAsync(recipeEntry);
                TempData["SuccessMessage"] = "Recipe updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the recipe.");
                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                return View(recipeEntry);
            }
        }

        // GET: Recipe/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

            [HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    try
    {
        await _recipeRepository.DeleteRecipeAsync(id);
        TempData["SuccessMessage"] = "Recipe deleted successfully.";
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "An error occurred while deleting the recipe.");
        TempData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
        var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View("Delete", recipe); // Return to the same Delete view if there was an error.
    }
}
// GET: Recipe/Details/5
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
                if (recipe == null)
                {
                    return NotFound();
                }
                return View(recipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the recipe details.");
                TempData["ErrorMessage"] = "Unable to fetch recipe details. Please try again later.";
                return View("Error");
            }
}



    }
}
