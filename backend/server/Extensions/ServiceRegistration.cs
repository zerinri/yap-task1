using Microsoft.Extensions.DependencyInjection;
using NormativeApp.Data;
using NormativeApp.Services;

namespace NormativeApp.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static void SetupServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
        }

    }
}
