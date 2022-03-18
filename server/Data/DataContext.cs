using server.Entities;
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
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(bi => bi.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(b => b.Ingredient)
                .WithMany(i => i.RecipeIngredients)
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
                new Category { Id = 4, Name = "Brunch" },
                new Category { Id = 5, Name = "Snack" },
                new Category { Id = 6, Name = "Midnight snack" },
                new Category { Id = 7, Name = "Healty snack" },
                new Category { Id = 8, Name = "Dessert" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
           new Ingredient { Id = 1, Name = "Flour", PurchaseUnitMeasure = UnitMeasureEnum.kg, PurchaseQuantity = 1, PurchasePrice = 10 },
           new Ingredient { Id = 2, Name = "Pepper", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 10, PurchasePrice = 4 },
           new Ingredient { Id = 3, Name = "Oil", PurchaseUnitMeasure = UnitMeasureEnum.l, PurchaseQuantity = 1, PurchasePrice = 7 },
           new Ingredient { Id = 4, Name = "Cheese", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 100, PurchasePrice = 15 },
           new Ingredient { Id = 5, Name = "Sugar", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 80, PurchasePrice = 3 },
           new Ingredient { Id = 6, Name = "Salt", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 70, PurchasePrice = 2 },
           new Ingredient { Id = 7, Name = "Meat", PurchaseUnitMeasure = UnitMeasureEnum.kg, PurchaseQuantity = 1, PurchasePrice = 20 }
           );
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

    }
}