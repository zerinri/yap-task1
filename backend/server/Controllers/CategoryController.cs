using Microsoft.AspNetCore.Mvc;
using server.Services;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories/{limit}")]
        public async Task<IActionResult> Get(int limit)
        {
            return Ok(await _categoryService.GetAllCategories(limit));
        }

    }
}
