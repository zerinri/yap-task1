using AutoMapper;
using server.Dtos.Category;
using server.Dtos.Ingredient;
using server.Dtos.Recipe;
using server.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<Category, GetCategoryDto>();

        }
    }
}