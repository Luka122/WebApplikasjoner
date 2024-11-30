using Exam.Models;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace Exam.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var nutritionContext = serviceScope.ServiceProvider.GetService<NutritionEntryDbContext>();
            var userContext = serviceScope.ServiceProvider.GetService<UserDbContext>();

            // Seed NutritionEntryDbContext
            if (nutritionContext != null)
            {
                nutritionContext.Database.EnsureDeleted();
                nutritionContext.Database.EnsureCreated();

                if (!nutritionContext.Entries.Any())
                {
                    var entries = new List<NutritionEntry>
                    {
                        new NutritionEntry { NutritionId = 1, Name = "Apple", FoodGroup = "Fruits", Calories = 95, Protein = 0.5, Fat = 0.3, Carbohydrates = 25, ImageURL = "/images/DbInit/apple.png"},
                        new NutritionEntry { NutritionId = 2, Name = "Chicken Breast", FoodGroup = "Meats", Calories = 165, Protein = 31, Fat = 3.6, Carbohydrates = 0, ImageURL = "/images/DbInit/chicken.png"},
                        new NutritionEntry { NutritionId = 3, Name = "Broccoli", FoodGroup = "Vegetables", Calories = 55, Protein = 4.0, Fat = 0.6, Carbohydrates = 11, ImageURL = "/images/DbInit/broccoli.png"},
                        new NutritionEntry { NutritionId = 4, Name = "Rice", FoodGroup = "Grains", Calories = 206, Protein = 4.3, Fat = 0.4, Carbohydrates = 45, ImageURL = "/images/DbInit/rice.png"},
                        new NutritionEntry { NutritionId = 5, Name = "Almonds", FoodGroup = "Nuts", Calories = 164, Protein = 6.0, Fat = 14.0, Carbohydrates = 6, ImageURL = "/images/DbInit/almonds.png"}
                    };

                    nutritionContext.AddRange(entries);
                    nutritionContext.SaveChanges();
                }
            }

            // Seed UserDbContext
            if (userContext != null)
            {
                userContext.Database.EnsureDeleted();
                userContext.Database.EnsureCreated();

                if (!userContext.Users.Any())
                {
                    var users = new List<User>
                    {
                        new User { UserId = 1, Username = "User1", Password = "Password1" },
                        new User { UserId = 2, Username = "User2", Password = "Password2" }
                    };

                    userContext.AddRange(users);
                    userContext.SaveChanges();
                }
            }
        }
    }
}