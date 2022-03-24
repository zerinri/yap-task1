using AutoMapper;
using NormativeApp.Core.Dtos.Category;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Core.Dtos.Recipe;
using NormativeApp.Core.Entities;
using NormativeApp.Services.Helpers;

namespace NormativeApp.Mapper
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