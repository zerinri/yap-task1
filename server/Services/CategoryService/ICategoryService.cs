using server.Dtos.Category;
using server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories(int limit);

    }
}