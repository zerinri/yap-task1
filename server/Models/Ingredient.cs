using server.Models;
using System.Collections.Generic;

namespace server.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public decimal MinimalUnitPrice { get; set; }

        public List<RecipeIngredient> Recipe_Ingredients { get; set; }
    }
}
