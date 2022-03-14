using server.Models;

namespace server.Dtos.Recipe
{
    public class AddRecipeIngredientDto
    {
        public int IngredientId { get; set; }

        public decimal Quantity { get; set; }
        public UnitMeasure UnitMeasure { get; set; }



    }
}
