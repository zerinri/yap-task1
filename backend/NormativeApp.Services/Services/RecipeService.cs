using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Core.Dtos.Recipe;
using NormativeApp.Core.Entities;
using NormativeApp.Database.Data;
using NormativeApp.Services.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NormativeApp.Services
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

        public async Task AddRecipeWithIngredients(AddRecipeDto recipe)
        {
            var newRecipe = new Recipe()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                CategoryId = recipe.CategoryId,
                CreatedDate = System.DateTime.Now
            };
            _context.Recipes.Add(newRecipe);
            _context.SaveChanges();

            var ingridents = new List<RecipeIngredient>();

            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
                ingridents.Add(new RecipeIngredient()
                {
                    RecipeId = newRecipe.Id,
                    IngredientId = recipeIngredient.IngredientId,
                    UnitMeasure = recipeIngredient.UnitMeasure,
                    Quantity = recipeIngredient.Quantity
                });

            }
            _context.RecipeIngredients.AddRange(ingridents);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<GetRecipeByIdDto>> RecipeGetById(int recipeId)
        {
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

            return new ServiceResponse<GetRecipeByIdDto>()
            {
                Data = new GetRecipeByIdDto
                {

                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Category = recipe.Category.Name,
                    CreatedDate = recipe.CreatedDate.ToString(),
                    TotalCost = CalculateTotalCost.RecipeTotalCost(recipe),
                    Ingredients = ingredients

                }
            };
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> RecipeGetByCategory(int categoryId)
        {
            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.CategoryId == categoryId)
                .Select(c => _mapper.Map<GetCategoryWithRecipeDto>(c))
                .ToListAsync();

            return new ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>()
            {
                Data = recipes
            };
        }



        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>> GetRecipeBySearch(string search)
        {
            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.Name == search)
                .ToListAsync();

            return new ServiceResponse<IEnumerable<GetCategoryWithRecipeDto>>()
            {
                Data = recipes
                .Select(r => new GetCategoryWithRecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCost = CalculateTotalCost.RecipeTotalCost(r),
                })
            };
        }
    }
}
