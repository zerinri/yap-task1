using server.Dtos.Recipe;
using System.Collections.Generic;

namespace server.Dtos.Category
{
    public class GetCategoryWithRecipesDto
    {
        public string Name { get; set; }
        public List<GetRecipeIngredientDto> RecipeIngredients { get; set; }
    }
}
