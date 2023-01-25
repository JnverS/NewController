using Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, NickName = "Tom", Lvl = 37, TotalScore = 10500 },
                    new User { Id = 2, NickName = "Bob", Lvl = 41, TotalScore = 50000 },
                    new User { Id = 3, NickName = "Sam", Lvl = 24, TotalScore = 5000 }
            );
        }*/
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=testdb;Port=5432;User ID=postgres;Password=postgres;Pooling=true;");
        }
        */
    }
}

