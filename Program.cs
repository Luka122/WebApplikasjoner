using Microsoft.EntityFrameworkCore;
using Exam.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data; // Add this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<NutritionDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Add a test operation
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<NutritionDbContext>();
    
    var nutrition = new NutritionModel
    {
        
        FoodItem = "Test Food",
        Calories = 22,
        Protein = 2221,
        Fat = 123,
        Carbohydrates = 765

    };
    
    context.Items.Add(nutrition);
    context.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();