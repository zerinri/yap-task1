using NormativeApp.Common.Entities;

namespace NormativeApp.Core.Dtos.Ingredient
{
    public class GetIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public UnitMeasureEnum UnitMeasure { get; set; }
        public decimal MinimalUnitPrice { get; set; }

    }
}
