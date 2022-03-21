using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Api.Services.RecipeService;
using Server.Common.Entities;
using Server.Core.Dtos.Ingredient;
using Server.Core.Dtos.Recipe;
using Server.Core.Entities;
using Server.Database.Data;
using Server.Services.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public void AddRecipeWithIngredients(AddRecipeDto recipe)
        {

            var _recipe = new Recipe()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                CategoryId = recipe.CategoryId,
                CreatedDate = System.DateTime.Now
            };
            _context.Recipes.Add(_recipe);
            _context.SaveChanges();

            var ingridents = new List<RecipeIngredient>();

            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
                ingridents.Add(new RecipeIngredient()
                {
                    RecipeId = _recipe.Id,
                    IngredientId = recipeIngredient.IngredientId,
                    UnitMeasure = recipeIngredient.UnitMeasure,
                    Quantity = recipeIngredient.Quantity
                });

            }
            _context.RecipeIngredients.AddRange(ingridents);
            _context.SaveChanges();
        }

        public async Task<ServiceResponse<GetRecipeByIdDto>> RecipeGetById(int recipeId)
        {
            var serviceResponse = new ServiceResponse<GetRecipeByIdDto>();

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == recipeId);

            var ingredients = recipe.RecipeIngredients.Select(i => new GetIngredientDto
            {
                Id = i.Ingredient.Id,
                Name = i.Ingredient.Name,
                PurchaseQuantity = i.Quantity,
                UnitMeasure = i.UnitMeasure,
                MinimalUnitPrice = i.Ingredient.PurchasePrice,
            });

            serviceResponse.Data = new GetRecipeByIdDto
            {

                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                Category = recipe.Category.Name,
                CreatedDate = recipe.CreatedDate.ToString(),
                TotalCost = CalculateTotalCost.RecipeTotalCost(recipe),
                Ingredients = ingredients

            };


            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> RecipeGetByCategory(int categoryId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.CategoryId == categoryId)
                .Select(c => _mapper.Map<GetCategoryWithRecipeDto>(c))
                .ToListAsync();

            serviceResponse.Data = recipes;

            return serviceResponse;
        }



        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> GetRecipeBySearch(string search)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.Name == search)
                .ToListAsync();

            serviceResponse.Data = recipes
                .Select(r => new GetCategoryWithRecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCost = CalculateTotalCost.RecipeTotalCost(r),
                });



            return serviceResponse;
        }
    }
}
