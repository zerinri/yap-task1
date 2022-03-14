using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Ingredient;
using server.Dtos.Recipe;
using server.Dtos.Recipe;
using server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class RecipeService 
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeService(IMapper mapper,DataContext context)
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
            _context.Recipe_Ingredients.AddRange(ingridents);
            _context.SaveChanges();
        }

        public async Task<ServiceResponse<GetRecipeById>> RecipeGetById(int recipeId)
        {
            var serviceResponse = new ServiceResponse<GetRecipeById>();

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Recipe_Ingredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == recipeId);

            var ingredients = recipe.Recipe_Ingredients.Select(i => new GetIngredientDto
            {
                Id = i.Ingredient.Id,
                Name = i.Ingredient.Name,
                PurchaseQuantity = i.Quantity,
                UnitMeasure = i.UnitMeasure,
                MinimalUnitPrice = i.Ingredient.MinimalUnitPrice,
            });

            serviceResponse.Data = new GetRecipeById
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                Category = recipe.Category.Name,
                Ingredients = ingredients,
                TotalCost = RecipeTotalCost(recipe)

            };


            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> RecipeGetByCategory(int categoryId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipe>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.Recipe_Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            serviceResponse.Data = recipes
                .Select(r => new GetCategoryWithRecipe
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCost = RecipeTotalCost(r)
                });


            return serviceResponse;
        }

        private decimal QtyConvert(decimal qty, UnitMeasure unit)
        {
            var convertedQty = qty / 1000;

            if (unit == UnitMeasure.g) return convertedQty;
            if (unit == UnitMeasure.ml) return convertedQty;

            return qty;
        }

        private decimal RecipeTotalCost(Recipe recipe)
        {
            var cost = recipe.Recipe_Ingredients.Select(i => new GetTotalCostDto
            {
                BaseQuantity = QtyConvert(i.Ingredient.PurchaseQuantity, i.Ingredient.UnitMeasure),
                UsedQuantity = QtyConvert(i.Quantity, i.UnitMeasure),
                Price = i.Ingredient.MinimalUnitPrice
            });

            decimal totalCost = cost.Sum(c => c.UsedQuantity * (c.Price / c.BaseQuantity));
            return totalCost;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryWithRecipe>>> GetRecipeBySearch(string search)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryWithRecipe>>();

            var recipes = await _context.Recipes
                .Include(ri => ri.Recipe_Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Where(c => c.Name == search)  
                .ToListAsync();

            serviceResponse.Data = recipes
                .Select(r => new GetCategoryWithRecipe
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCost = RecipeTotalCost(r)
                });


           
            return serviceResponse;
        }
    }
}
