using Microsoft.EntityFrameworkCore;

namespace Exam.Models
{
    public class NutritionEntryDbContext : DbContext
    {
        public NutritionEntryDbContext(DbContextOptions<NutritionEntryDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<NutritionEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutritionEntry>()
                .HasKey(n => n.NutritionId);

            modelBuilder.Entity<NutritionEntry>()
                .Property(n => n.NutritionId)
                .ValueGeneratedOnAdd();
        }
    }
}
