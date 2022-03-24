using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories(int limit);

    }
}