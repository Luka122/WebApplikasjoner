using Microsoft.EntityFrameworkCore;
using Exam.DAL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext and Repositories
builder.Services.AddDbContext<NutritionEntryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NutritionConnection")));

builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RecipeConnection")));

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

// Register Repositories
builder.Services.AddScoped<INutritionRepository, NutritionRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

// Configure Logging using Serilog
var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File($"Logs/api_{DateTime.Now:yyyyMMdd_HHmmss}.log");

loggerConfiguration.Filter.ByExcluding(e => e.Properties.TryGetValue("SourceContext", out var value) &&
                                            e.Level == Serilog.Events.LogEventLevel.Information &&
                                            e.MessageTemplate.Text.Contains("Executed DbCommand"));

var logger = loggerConfiguration.CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    DBInit.Seed(app);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.MapControllerRoute(name: "api", pattern: "{controller}/{action=Index}/{id?}");

app.Run();

