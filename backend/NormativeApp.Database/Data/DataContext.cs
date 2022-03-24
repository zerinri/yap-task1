using Microsoft.EntityFrameworkCore;
using NormativeApp.Core.Entities;
using NormativeApp.Database.DataSeed.CategorySeed;
using NormativeApp.Database.DataSeed.IngredientSeed;

namespace NormativeApp.Database.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(b => b.Recipe)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(bi => bi.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(b => b.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(bi => bi.IngredientId);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"));

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "admin", PasswordHash = passwordHash, PasswordSalt = hmac.Key });

            modelBuilder.Categories();
            modelBuilder.Ingredients();
        }
    }
}