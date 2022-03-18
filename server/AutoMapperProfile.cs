using AutoMapper;
using server.Dtos.Category;
using server.Dtos.Ingredient;
using server.Dtos.Recipe;
using server.Entities;
using Server.Api.Helpers;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Recipe, GetRecipeDto>();

            CreateMap<Recipe, GetRecipeById>();          
            CreateMap<Ingredient, GetIngredientDto>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<RecipeIngredient, GetRecipeById>()
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => CalculateTotalCost.RecipeTotalCost(src.Quantity,src.UnitMeasure,src.Ingredient.PurchasePrice,src.Recipe)));

        }
    }
}