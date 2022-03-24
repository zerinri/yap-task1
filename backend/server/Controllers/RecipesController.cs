using Microsoft.AspNetCore.Mvc;
using NormativeApp.Services;
using NormativeApp.Core.Dtos.Recipe;
using System.Threading.Tasks;

namespace NormativeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRecipeDto recipe)
        {
            await _recipeService.AddRecipeWithIngredients(recipe);
            return Ok(recipe);
        }

        [HttpGet("GetRecipeById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _recipeService.RecipeGetById(id));
        }

        [HttpGet("GetRecipeByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            return Ok(await _recipeService.RecipeGetByCategory(categoryId));
        }

        [HttpGet("GetRecipeBySearch/{search}")]
        public async Task<IActionResult> Get(string search)
        {
            return Ok(await _recipeService.GetRecipeBySearch(search));
        }


    }
}
