using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Recipe;
using server.Models;
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
      
        [EnableCors("CORS")]
        [HttpPost("AddRecipe")]
        public IActionResult AddRecipeWithIngredients([FromBody]AddRecipeDto recipe)
        {
            _recipeService.AddRecipeWithIngredients(recipe);
            return Ok();
        }

        [EnableCors("CORS")]
        [HttpGet("GetRecipeById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> RecipeGetById(int id)
        {
            return Ok(await _recipeService.RecipeGetById(id));
        }

        [EnableCors("CORS")]
        [HttpGet("GetRecipeByCategoryId/{id}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> RecipeGetByCategory(int id)
        {
            return Ok(await _recipeService.RecipeGetByCategory(id));
        }

        [EnableCors("CORS")]
        [HttpGet("GetRecipeBySearch/{search}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> GetRecipeBySearch(string search)
        {
            return Ok(await _recipeService.GetRecipeBySearch(search));
        }


    }
}
