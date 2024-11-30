using Microsoft.AspNetCore.Mvc;
using Exam.DAL;
using Exam.Models;

namespace Exam.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IActionResult Index()
        {
            var recipes = _recipeRepository.GetAllRecipes();
            return View(recipes);
        }

        public IActionResult Details(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            return View(recipe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecipeEntry recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeRepository.AddRecipe(recipe);
                _recipeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        public IActionResult Edit(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecipeEntry recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeRepository.UpdateRecipe(recipe);
                _recipeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        public IActionResult Delete(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _recipeRepository.DeleteRecipe(id);
            _recipeRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
