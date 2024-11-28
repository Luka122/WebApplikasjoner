using Microsoft.EntityFrameworkCore;
using Exam.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NutritionEntryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NutritionConnection")));

builder.Services.AddScoped<INutritionRepository, NutritionRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

app.MapDefaultControllerRoute();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();