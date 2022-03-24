using Microsoft.AspNetCore.Mvc;
using NormativeApp.Services;
using System.Threading.Tasks;

namespace NormativeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int limit)
        {
            return Ok(await _categoryService.GetAllCategories(limit));
        }

    }
}
