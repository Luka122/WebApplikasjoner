using Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Exam.DAL
{
    public class NutritionEntryDbContext : IdentityDbContext
    {
        public NutritionEntryDbContext(DbContextOptions<NutritionEntryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<NutritionEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NutritionEntry>()
                .HasKey(n => n.NutritionId);

            modelBuilder.Entity<NutritionEntry>()
                .Property(n => n.NutritionId)
                .ValueGeneratedOnAdd();
        }
    }
}
