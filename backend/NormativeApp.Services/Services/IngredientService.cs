using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NormativeApp.Common.Entities;
using NormativeApp.Core.Dtos.Ingredient;
using NormativeApp.Database.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NormativeApp.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public IngredientService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients()
        {
            var dbIngredients = await _context.Ingredients.ToListAsync();

            var ingredients = dbIngredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();

            return new ServiceResponse<List<GetIngredientDto>>()
            {
                Data = ingredients
            };
        }
    }
}
