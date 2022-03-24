using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Entities;
using System;

namespace NormativeApp.Database.DataSeed.IngredientSeed
{
    public static class IngredientSeed
    {
        public static void Ingredients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
              new Ingredient { Id = 1, Name = "Flour", PurchaseUnitMeasure = UnitMeasureEnum.kg, PurchaseQuantity = 1, PurchasePrice = 10, CreatedDate = DateTime.Now },
              new Ingredient { Id = 2, Name = "Pepper", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 10, PurchasePrice = 4, CreatedDate = DateTime.Now },
              new Ingredient { Id = 3, Name = "Oil", PurchaseUnitMeasure = UnitMeasureEnum.l, PurchaseQuantity = 1, PurchasePrice = 7, CreatedDate = DateTime.Now },
              new Ingredient { Id = 4, Name = "Cheese", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 100, PurchasePrice = 15, CreatedDate = DateTime.Now },
              new Ingredient { Id = 5, Name = "Sugar", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 80, PurchasePrice = 3, CreatedDate = DateTime.Now },
              new Ingredient { Id = 6, Name = "Salt", PurchaseUnitMeasure = UnitMeasureEnum.g, PurchaseQuantity = 70, PurchasePrice = 2, CreatedDate = DateTime.Now },
              new Ingredient { Id = 7, Name = "Meat", PurchaseUnitMeasure = UnitMeasureEnum.kg, PurchaseQuantity = 1, PurchasePrice = 20, CreatedDate = DateTime.Now }
         );
        }
    }
}
