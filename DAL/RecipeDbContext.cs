using Microsoft.EntityFrameworkCore;
using Exam.Models;

namespace Exam.DAL
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
        }

        public DbSet<RecipeEntry> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeEntry>().HasKey(r => r.RecipeId);
        }
    }
}
