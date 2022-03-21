using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Services;
using Server.Common.Entities;
using Server.Core.Dtos.Ingredient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;
        public IngredientController(IngredientService igredientService)
        {
            _ingredientService = igredientService;
        }

        [HttpGet("GetAllIngredients")]
        public async Task<ActionResult<ServiceResponse<List<GetIngredientDto>>>> Get()
        {
            return Ok(await _ingredientService.GetAllIngredients());
        }
    }
}
