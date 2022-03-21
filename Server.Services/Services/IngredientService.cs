using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Common.Entities;
using Server.Core.Dtos.Ingredient;
using Server.Database.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
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
            var serviceResponse = new ServiceResponse<List<GetIngredientDto>>();

            var dbIngredients = await _context.Ingredients.ToListAsync();

            serviceResponse.Data = dbIngredients.Select(i => _mapper.Map<GetIngredientDto>(i)).ToList();

            return serviceResponse;
        }
    }
}
