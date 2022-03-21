using Server.Core.Dtos.RecipeIngredient;
using System.Collections.Generic;

namespace Server.Core.Dtos.Category
{
    public class GetCategoryWithRecipesDto
    {
        public string Name { get; set; }
        public List<GetRecipeIngredientDto> RecipeIngredients { get; set; }
    }
}
