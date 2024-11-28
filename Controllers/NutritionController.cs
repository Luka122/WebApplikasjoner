using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Exam.DAL;

public class NutritionController : Controller
{
    private readonly INutritionRepository _nutritionRepository;

    public NutritionController(INutritionRepository nutritionRepository)
    {
        _nutritionRepository = nutritionRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var entries = await _nutritionRepository.GetAll();
        return View("NutritionTable", entries);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            var newEntry = new NutritionEntry
            {
                Name = entry.Name,
                FoodGroup = entry.FoodGroup,
                Calories = entry.Calories,
                Protein = entry.Protein,
                Fat = entry.Fat,
                Carbohydrates = entry.Carbohydrates
            };

            await _nutritionRepository.Create(newEntry);

            return RedirectToAction("Index");
        }

        // Error Response, not implemented
        return Json(new { success = false, message = "Invalid data." });
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {

        bool entryDeleted = await _nutritionRepository.Delete(id);

        // Throw error here if failed or something

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var entry = await _nutritionRepository.GetById(id);

        if (entry == null)
        {
            return NotFound();
        }

        return View("Update", entry);
    }


    [HttpPost]
    public async Task<IActionResult> Update(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            await _nutritionRepository.Update(entry);
            return RedirectToAction("Index");
        }
        return View(entry);
    }
}