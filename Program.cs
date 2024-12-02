using Microsoft.EntityFrameworkCore;
using Exam.DAL;
using Serilog;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register DbContext and Repositories
builder.Services.AddDbContext<NutritionEntryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NutritionConnection")));

builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RecipeConnection")));


// Register Identity Services
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<NutritionEntryDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
});

// Register Repositories
builder.Services.AddScoped<INutritionRepository, NutritionRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Nutri.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.IsEssential = true;
});

// Configure Logging using Serilog
var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File($"Logs/Nutri_{DateTime.Now:yyyyMMdd_HHmmss}.log");

loggerConfiguration.Filter.ByExcluding(e => e.Properties.TryGetValue("SourceContext", out var value) &&
                            e.Level == Serilog.Events.LogEventLevel.Information &&
                            e.MessageTemplate.Text.Contains("Executed DbCommand"));

var logger = loggerConfiguration.CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();