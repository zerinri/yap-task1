using Microsoft.EntityFrameworkCore;
using NormativeApp.Core.Entities;
using System;

namespace NormativeApp.Database.DataSeed.CategorySeed
{
    public static class CategorySeed
    {
        public static void Categories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Breakfast", CreatedDate = DateTime.Now },
            new Category { Id = 2, Name = "Lunch", CreatedDate = DateTime.Now },
            new Category { Id = 3, Name = "Dinner", CreatedDate = DateTime.Now },
            new Category { Id = 4, Name = "Brunch", CreatedDate = DateTime.Now },
            new Category { Id = 5, Name = "Snack", CreatedDate = DateTime.Now },
            new Category { Id = 6, Name = "Midnight snack", CreatedDate = DateTime.Now },
            new Category { Id = 7, Name = "Healty snack", CreatedDate = DateTime.Now },
            new Category { Id = 8, Name = "Dessert", CreatedDate = DateTime.Now }
        );
        }
    }
}
