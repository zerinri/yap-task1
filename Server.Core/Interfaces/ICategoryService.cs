using Server.Common.Entities;
using Server.Core.Dtos.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories(int limit);

    }
}