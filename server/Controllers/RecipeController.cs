using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Recipe;
using server.Entities;
using server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost("AddRecipe")]
        public IActionResult Post([FromBody] AddRecipeDto recipe)
        {
            _recipeService.AddRecipeWithIngredients(recipe);
            return Ok();
        }

        [HttpGet("GetRecipeById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> Get(int id)
        {
            return Ok(await _recipeService.RecipeGetById(id));
        }

        [HttpGet("GetRecipeByCategoryId/{categoryId}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> GetByCategoryId(int categoryId)
        {
            return Ok(await _recipeService.RecipeGetByCategory(categoryId));
        }

        [HttpGet("GetRecipeBySearch/{search}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> Get(string search)
        {
            return Ok(await _recipeService.GetRecipeBySearch(search));
        }


    }
}
