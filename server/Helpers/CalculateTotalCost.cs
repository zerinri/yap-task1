using server.Dtos.Recipe;
using server.Entities;
using System.Linq;

namespace Server.Api.Helpers
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

        public static decimal RecipeTotalCost(decimal Quantity, UnitMeasureEnum UnitMeasure, decimal PurchasePrice,Recipe recipe)
        {
      
            var cost = recipe.RecipeIngredients.Select(i => new GetTotalCostDto
            {
                BaseQuantity = QtyConvert(i.Ingredient.PurchaseQuantity, i.Ingredient.PurchaseUnitMeasure),
                UsedQuantity = QtyConvert(Quantity, UnitMeasure),
                Price = PurchasePrice
            });

            decimal totalCost = cost.Sum(c => c.UsedQuantity * (c.Price / c.BaseQuantity));
            return totalCost;
        }
    }
}
