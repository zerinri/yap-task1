using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Category;
using NormativeApp.Database.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Services
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

            var dbCategories = await _context.Categories.ToListAsync();

            var categories = dbCategories
                                   .Select(c => _mapper.Map<GetCategoryDto>(c))
                                   .Skip(limit)
                                   .Take(4)
                                   .ToList();

            return new ServiceResponse<List<GetCategoryDto>>()
            {
                Data = categories
            };
        }

    }
}
