using AutoMapper;
using Server.Core.Dtos.Category;
using Server.Core.Dtos.Ingredient;
using Server.Core.Dtos.Recipe;
using Server.Core.Entities;
using Server.Services.Helpers;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Recipe, GetRecipeDto>();

            CreateMap<Recipe, GetRecipeByIdDto>();          
            CreateMap<Ingredient, GetIngredientDto>();

            CreateMap<Category, GetCategoryDto>();

            CreateMap<RecipeIngredient, GetRecipeByIdDto>()
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => CalculateTotalCost.RecipeTotalCost(src.Recipe)));

            CreateMap<Recipe, GetCategoryWithRecipeDto>()
           .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => CalculateTotalCost.RecipeTotalCost(src)));
        }
    }
}