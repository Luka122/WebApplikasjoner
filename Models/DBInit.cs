using Microsoft.EntityFrameworkCore;

namespace Exam.Models;
public static class DBInit
{
    public static void Seed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        NutritionEntryDbContext context = serviceScope.ServiceProvider.GetService<NutritionEntryDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        if (!context.Entries.Any())
        {
            var entries = new List<NutritionEntry>
            {
                new NutritionEntry { NutritionId = 1, Name = "Apple", FoodGroup = "Fruits", Calories = 95, Protein = 0.5, Fat = 0.3, Carbohydrates = 25 },
                new NutritionEntry { NutritionId = 2, Name = "Chicken Breast", FoodGroup = "Meats", Calories = 165, Protein = 31, Fat = 3.6, Carbohydrates = 0 },
                new NutritionEntry { NutritionId = 3, Name = "Broccoli", FoodGroup = "Vegetables", Calories = 55, Protein = 4.0, Fat = 0.6, Carbohydrates = 11 },
                new NutritionEntry { NutritionId = 4, Name = "Rice", FoodGroup = "Grains", Calories = 206, Protein = 4.3, Fat = 0.4, Carbohydrates = 45 },
                new NutritionEntry { NutritionId = 5, Name = "Almonds", FoodGroup = "Nuts", Calories = 164, Protein = 6.0, Fat = 14.0, Carbohydrates = 6 }
            };

            context.AddRange(entries);
            context.SaveChanges();

        }

    }
}
