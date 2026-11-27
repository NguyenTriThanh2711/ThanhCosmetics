using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Service.Interfaces;

using Microsoft.AspNetCore.Http;
using AutoMapper;
namespace ThanhCometics.Service.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper) 
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<MethodResult<IngredientViewModel?>> GetIngredientsAsync()
        {
            var ingredietns = await _ingredientRepository.GetIngredientsAsync();
            var result = _mapper.Map<IngredientViewModel>(ingredietns);
            if (result == null) return new MethodResult<IngredientViewModel?>.Failure("Can't found any ingredient", StatusCodes.Status404NotFound);
            return new MethodResult<IngredientViewModel?>.Success(result);
        }
    }
}
