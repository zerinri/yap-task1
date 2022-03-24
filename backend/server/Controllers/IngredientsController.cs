using Microsoft.AspNetCore.Mvc;
using NormativeApp.Services;
using System.Threading.Tasks;

namespace NormativeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ingredientService.GetAllIngredients());
        }
    }
}
