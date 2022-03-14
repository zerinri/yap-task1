using server.Dtos.Ingredient;
using server.Models;
using System.Collections.Generic;

namespace server.Dtos.Recipe
{
    public class GetRecipeIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public List<GetIngredientDto> RecipeIngredients { get; set; }

      
    }
}
