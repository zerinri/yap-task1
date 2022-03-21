using Server.Common.Entities;

namespace Server.Core.Dtos.RecipeIngredient
{
    public class AddRecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public UnitMeasureEnum UnitMeasure { get; set; }

    }
}
