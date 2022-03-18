using server.Entities;

namespace server.Dtos.Recipe
{
    public class AddRecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public UnitMeasureEnum UnitMeasure { get; set; }

    }
}
