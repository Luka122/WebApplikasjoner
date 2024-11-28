using Exam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Exam.DAL
{
    public class NutritionEntryDbContext : IdentityDbContext<IdentityUser>
    {
        public NutritionEntryDbContext(DbContextOptions<NutritionEntryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<NutritionEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // This needs to be called for ASP.NET Core Identity to work.
            
            modelBuilder.Entity<NutritionEntry>()
                .HasKey(n => n.NutritionId);

            modelBuilder.Entity<NutritionEntry>()
                .Property(n => n.NutritionId)
                .ValueGeneratedOnAdd();
        }
    }
}