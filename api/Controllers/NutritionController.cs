using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Exam.DAL;
using Exam.DTOs;
using Exam.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.HttpResults;

[ApiController]
[Route("api/[controller]")]
public class NutritionAPIController : Controller
{
    private readonly INutritionRepository _nutritionRepository;
    private readonly ILogger<NutritionAPIController> _logger;

    public NutritionAPIController(INutritionRepository nutritionRepository, ILogger<NutritionAPIController> logger)
    {
        _nutritionRepository = nutritionRepository;
        _logger = logger;
    }

    [HttpGet("Entries")]
    public async Task<IActionResult> Entries()
    {
        var entries = await _nutritionRepository.GetAll();

        if (entries == null)
        {
            _logger.LogError("[NutritionAPIController] Entries not found while executing _nutritionRepository.GetAll()");
            return NotFound("Entries list not found");
        }

        var entryDtos = entries.Select(item => new NutritionDto
        {
            NutritionId = item.NutritionId,
            Name = item.Name,
            FoodGroup = item.FoodGroup,
            Calories = item.Calories,
            Protein = item.Protein,
            Fat = item.Fat,
            Carbohydrates = item.Carbohydrates,
            ImageURL = item.ImageURL
        });

        return Ok(entryDtos);
    }
}

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
    [Authorize]
    public IActionResult Create()
    {
        return View(new NutritionEntry());
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(NutritionEntry entry)
    {
        if (ModelState.IsValid)
        {
            bool returnOk = await _nutritionRepository.Create(entry);

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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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