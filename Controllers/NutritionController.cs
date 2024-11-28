using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Exam.DAL;
using Exam.ViewModels;

public class NutritionController : Controller
{
    private readonly INutritionRepository _nutritionRepository;
    private readonly ILogger<NutritionController> _logger;

    public NutritionController(INutritionRepository nutritionRepository, ILogger<NutritionController> logger)
    {
        _nutritionRepository = nutritionRepository;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index()
    {
        var entries = await _nutritionRepository.GetAll();

        return View("NutritionTable", entries);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new NutritionEntry());
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

            bool returnOk = await _nutritionRepository.Create(newEntry);

            if (returnOk)
            {
                return RedirectToAction("Index");
            }


        }

        _logger.LogWarning("[NutritionController] Entry creation failed: {@entry}", entry);
        return RedirectToAction("Index");
    }
    
    // TODO: Lecture/Demo has a confirmation as well ? do we need
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {

        bool returnOk = await _nutritionRepository.Delete(id);

        if (returnOk)
        {
            return RedirectToAction("Index");
        }

        _logger.LogWarning("[NutritionController] Entry deletion failed by NutritionId {id}", id);
        return BadRequest("Entry deletion failed");
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var entry = await _nutritionRepository.GetById(id);

        if (entry == null)
        {
            _logger.LogError("[NutritionController] Entry not found when updating NutritionId {id}", id);
            return BadRequest("Item not found for given NutritionId");
        }

        return View("Update", entry);
    }


    [HttpPost]
    public async Task<IActionResult> Update(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            bool returnOk = await _nutritionRepository.Update(entry);
            if (returnOk)
            {
                return RedirectToAction("Index");
            }
        }

        _logger.LogWarning("[NutritionController] Entry update failed: {@entry}", entry);
        return View(entry);
    }
}