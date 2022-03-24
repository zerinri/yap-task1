using NormativeApp.Core.Dtos.Ingredient;
using System.Collections.Generic;

namespace NormativeApp.Core.Dtos.RecipeIngredient
{
    public class GetRecipeIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public List<GetIngredientDto> RecipeIngredients { get; set; }

      
    }
}
