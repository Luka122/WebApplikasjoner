using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public class NutritionDbContext : DbContext
{
    public NutritionDbContext(DbContextOptions<NutritionDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<NutritionModel> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NutritionModel>()
            .Property(n => n.Id)
            .ValueGeneratedOnAdd();
    }
}