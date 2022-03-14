using server.Dtos.Ingredient;
using server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IIngredientService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients();
    }
}