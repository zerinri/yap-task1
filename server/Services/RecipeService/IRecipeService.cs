using server.Dtos.Recipe;
using server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Api.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<ServiceResponse<IEnumerable<GetRecipeById>>> RecipeGetById(int recipeId);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> RecipeGetByCategory(int categoryId);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> GetRecipeBySearch(string search);
    }
}
