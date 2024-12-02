using Exam.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var nutritionContext = serviceScope.ServiceProvider.GetService<NutritionEntryDbContext>();
            var recipeContext = serviceScope.ServiceProvider.GetService<RecipeDbContext>();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();

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

           

            // Seed RecipeDbContext
            if (recipeContext != null)
            {
                recipeContext.Database.EnsureDeleted();
                recipeContext.Database.EnsureCreated();

                if (!recipeContext.Recipes.Any())
                {
                    var recipes = new List<RecipeEntry>
                    {
                        new RecipeEntry { RecipeId = 1, Name = "Spaghetti Bolognese", Description = "A classic Italian pasta dish with a rich and savory meat sauce.", CookingTime = 30, ImageURL = "/images/DbInit/spaghettibolognese.png", Ingredients = "Spaghetti, Ground beef, Tomatoes, Onion, Garlic, Olive oil, Salt, Pepper, Parmesan cheese" },
                        new RecipeEntry { RecipeId = 2, Name = "Caesar Salad", Description = "A healthy green salad with creamy Caesar dressing and crispy croutons.", CookingTime = 15, ImageURL = "/images/DbInit/caesersalad.png", Ingredients = "Romaine lettuce, Caesar dressing, Croutons, Parmesan cheese, Black pepper" },
                        new RecipeEntry { RecipeId = 3, Name = "Grilled Chicken", Description = "Juicy grilled chicken breasts seasoned with herbs and spices.", CookingTime = 25, ImageURL = "/images/DbInit/grilledchicken.png", Ingredients = "Chicken breasts, Olive oil, Lemon, Garlic, Rosemary, Salt, Pepper" },
                        new RecipeEntry { RecipeId = 4, Name = "Vegetable Stir-Fry", Description = "A colorful mix of stir-fried vegetables in a savory soy-based sauce.", CookingTime = 20, ImageURL = "/images/DbInit/vegetablestirfry.png", Ingredients = "Broccoli, Bell peppers, Carrots, Soy sauce, Ginger, Garlic, Olive oil" }
                    };

                    recipeContext.AddRange(recipes);
                    recipeContext.SaveChanges();
                }
            }

            // Seed default Identity user
            if (userManager != null)
            {
                const string email = "admin@test.com";
                const string username = "admin@test.com";
                const string password = "Test123456.";

                var defaultUser = userManager.FindByEmailAsync(email).Result;
                if (defaultUser == null)
                {
                    var newUser = new IdentityUser
                    {
                        UserName = username,
                        Email = email,
                    };

                    var result = userManager.CreateAsync(newUser, password).Result;
                }
            }
        }
    }
}