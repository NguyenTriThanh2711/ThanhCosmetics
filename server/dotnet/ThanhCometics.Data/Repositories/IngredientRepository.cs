using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;

using Microsoft.EntityFrameworkCore;
namespace ThanhCometics.Repository.Repositories
{
    public class IngredientRepository : Repository<Ingredient> , IIngredientRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ThanhCometicsDBContext _dbContext;

        public IngredientRepository(IUnitOfWork unitOfWork, IMapper mapper, ThanhCometicsDBContext dbContext) : base(dbContext) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientViewModel?>> GetIngredientsAsync()
        {
            return await Entities.ProjectTo<IngredientViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    
    }
}
