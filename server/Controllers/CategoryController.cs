using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Category;
using server.Dtos.Ingredient;
using server.Models;
using server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [EnableCors("CORS")]
        [HttpGet("GetRecipesFromCategory/{id}")]
        public IActionResult GetCategoryData(int id)
        {
            var _response = _categoryService.GetCategoryData(id);
            return Ok(_response);
        }
        [EnableCors("CORS")]
        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

    }
}
