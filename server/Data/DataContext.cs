using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(b => b.Recipe)
                .WithMany(i => i.Recipe_Ingredients)
                .HasForeignKey(bi => bi.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(b => b.Ingredient)
                .WithMany(i => i.Recipe_Ingredients)
                .HasForeignKey(bi => bi.IngredientId);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"));

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Username = "admin", PasswordHash = passwordHash, PasswordSalt = hmac.Key }

     ); ;

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Breakfast", },
                new Category { Id = 2, Name = "Lunch" },
                new Category { Id = 3, Name = "Dinner", },
                new Category { Id = 5, Name = "Brunch" },
                new Category { Id = 6, Name = "Snack" },
                new Category { Id = 7, Name = "Midnight snack" },
                new Category { Id = 9, Name = "Healty snack" },
                new Category { Id = 10, Name = "Dessert" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
           new Ingredient { Id = 1, Name = "Flour", UnitMeasure = UnitMeasure.kg, PurchaseQuantity = 1, MinimalUnitPrice = 10 },
           new Ingredient { Id = 2, Name = "Pepper", UnitMeasure = UnitMeasure.g, PurchaseQuantity = 10, MinimalUnitPrice = 4 },
           new Ingredient { Id = 3, Name = "Oil", UnitMeasure = UnitMeasure.l, PurchaseQuantity = 1, MinimalUnitPrice = 7 },
           new Ingredient { Id = 4, Name = "Cheese", UnitMeasure = UnitMeasure.g, PurchaseQuantity = 100, MinimalUnitPrice = 15 },
           new Ingredient { Id = 5, Name = "Sugar", UnitMeasure = UnitMeasure.g, PurchaseQuantity = 80, MinimalUnitPrice = 3 },
           new Ingredient { Id = 6, Name = "Salt", UnitMeasure = UnitMeasure.g, PurchaseQuantity = 70, MinimalUnitPrice = 2 },
           new Ingredient { Id = 7, Name = "Meat", UnitMeasure = UnitMeasure.kg, PurchaseQuantity = 1, MinimalUnitPrice = 20 }
           );
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> Recipe_Ingredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

    }
}