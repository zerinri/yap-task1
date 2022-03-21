using Server.Common.Entities;
using Server.Core.Dtos.Recipe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Api.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<ServiceResponse<GetRecipeByIdDto>> RecipeGetById(int recipeId);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> RecipeGetByCategory(int categoryId);
        Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> GetRecipeBySearch(string search);
    }
}
