using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.DAL
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();
            
            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "User1", Password = "Password1" },
                new User { UserId = 2, Username = "User2", Password = "Password2" }
                // Add more users as needed
            );
        }
    }
}