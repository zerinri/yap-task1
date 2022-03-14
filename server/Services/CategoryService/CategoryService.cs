using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Category;
using server.Dtos.Ingredient;
using server.Dtos.Recipe;
using server.Dtos.Recipe;
using server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, DataContext context)
        {

            _mapper = mapper;
            _context = context;
        }
        public GetCategoryWithRecipesDto GetCategoryData(int categoryId)
        {
            var serviceResponse = _context.Categories.Include(i=>i.Recipes)
                .ThenInclude(ri=>ri.Recipe_Ingredients)
                .Where(k => k.Id == categoryId)
                .Select(c => new GetCategoryWithRecipesDto()
                {
                    Name = c.Name,
                    RecipeIngredients = c.Recipes.Select(s => new GetRecipeIngredientDto()
                    {
                        Id = s.Id,
                        Name = s.Name,                        
                        //TotalCost = RecipeTotalCost(s.Recipe_Ingredients),
                        RecipeIngredients = s.Recipe_Ingredients.Select(n => new GetIngredientDto()
                        {
                            Name = n.Ingredient.Name,
                            MinimalUnitPrice = n.Ingredient.MinimalUnitPrice,
                            PurchaseQuantity = n.Quantity,
                            UnitMeasure = n.UnitMeasure,                           
                        }).ToList(),
                        }).ToList(),
                }).FirstOrDefault();

        return serviceResponse;
        }


        //private decimal RecipeTotalCost(List<Recipe_Ingredient> Recipe_Ingredients)
        //{
        //    decimal total_cost = 0;
        //    decimal userQuantity = 0;
        //    decimal seededQuantity = 0;
        //    foreach (Recipe_Ingredient ri in Recipe_Ingredients)
        //    {
        //        if (ri.UnitMeasure == UnitMeasure.g)
        //        {
        //            userQuantity = ri.Quantity / 1000;

        //        };

        //        if (ri.Ingredient.UnitMeasure == UnitMeasure.g)
        //        {
        //            seededQuantity = ri.Ingredient.PurchaseQuantity / 1000;

        //        }

        //        var Price = ri.Ingredient.MinimalUnitPrice;

        //        total_cost = total_cost + (userQuantity * (Price / seededQuantity));
        //    }

        //    return total_cost;
        //}

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

            var dbCategories = await _context.Categories.ToListAsync();

            serviceResponse.Data = dbCategories
                                   .Select(c => _mapper.Map<GetCategoryDto>(c))
                                   .ToList();

            return serviceResponse;
        }

    }
}
