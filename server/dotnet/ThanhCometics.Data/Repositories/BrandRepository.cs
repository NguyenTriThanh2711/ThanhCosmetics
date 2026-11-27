using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ThanhCometicsDBContext _dbContext;

        public BrandRepository(IUnitOfWork unitOfWork, IMapper mapper, ThanhCometicsDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BrandViewModel>> GetBrandsAsync()
        {
            return await Entities
                .ProjectTo<BrandViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
