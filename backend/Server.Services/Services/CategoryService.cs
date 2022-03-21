using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Common.Entities;
using Server.Core.Dtos.Category;
using Server.Database.Data;
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

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories(int limit)
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

            var dbCategories = await _context.Categories.ToListAsync();

            serviceResponse.Data = dbCategories
                                   .Select(c => _mapper.Map<GetCategoryDto>(c))
                                   .Skip(limit)
                                   .Take(4)
                                   .ToList();

            return serviceResponse;
        }

    }
}
