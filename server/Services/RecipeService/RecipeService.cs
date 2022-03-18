using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Ingredient;
using server.Dtos.Recipe;
using server.Entities;
using Server.Api.Services.RecipeService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Api.Helpers;

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

        public async Task<ServiceResponse<IEnumerable<GetRecipeById>>> RecipeGetById(int recipeId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetRecipeById>>();

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == recipeId);


            serviceResponse.Data = recipe.RecipeIngredients.Select(i => _mapper.Map<GetRecipeById>(i));

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> RecipeGetByCategory(int categoryId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipe>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            serviceResponse.Data = recipes
                .Select(r => new GetCategoryWithRecipe
                {
                    Id = r.Id,
                    Name = r.Name,
                    //TotalCost = RecipeTotalCost(r)
                });

            return serviceResponse;
        }

       

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> GetRecipeBySearch(string search)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipe>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.Name == search)
                .ToListAsync();

            serviceResponse.Data = recipes
                .Select(r => new GetCategoryWithRecipe
                {
                    Id = r.Id,
                    Name = r.Name,
                    //TotalCost = RecipeTotalCost(r)
                });



            return serviceResponse;
        }
    }
}
