using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.RecipeIngredient;
using NormativeApp.Core.Entities;
using System.Linq;

namespace NormativeApp.Services.Helpers
{
    public class CalculateTotalCost
    {
        private static decimal QtyConvert(decimal qty, UnitMeasureEnum unit)
        {
            var convertedQty = qty / 1000;

            if (unit == UnitMeasureEnum.g) return convertedQty;
            if (unit == UnitMeasureEnum.ml) return convertedQty;

            return qty;
        }

        public static decimal RecipeTotalCost(Recipe recipe)
        {
      
            var cost = recipe.RecipeIngredients.Select(i => new GetTotalCostDto
            {
                BaseQuantity = QtyConvert(i.Ingredient.PurchaseQuantity, i.Ingredient.PurchaseUnitMeasure),
                UsedQuantity = QtyConvert(i.Quantity, i.UnitMeasure),
                Price = i.Ingredient.PurchasePrice
            });

            decimal totalCost = cost.Sum(c => c.UsedQuantity * (c.Price / c.BaseQuantity));
            return totalCost;
        }
    }
}
