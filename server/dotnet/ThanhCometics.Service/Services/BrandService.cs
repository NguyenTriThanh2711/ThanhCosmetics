using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        
        public BrandService (IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<MethodResult<IEnumerable<BrandViewModel>>> GetBrandsAsync()
        {
            var result = await _brandRepository.GetBrandsAsync();
            if (result == null) return new MethodResult<IEnumerable<BrandViewModel>>.Failure("There are none brands", StatusCodes.Status404NotFound);
            return new MethodResult<IEnumerable<BrandViewModel>>.Success(result);
        }
    }
}
