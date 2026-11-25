using AutoMapper;
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
    public class SkinTestService : ISkinTestService
    {
        private readonly ISkinTestRepository _skinTestRepository;
        private readonly IMapper _mapper;
        public SkinTestService(IMapper mapper, ISkinTestRepository skinTestRepository) 
        {
            _mapper = mapper;
            _skinTestRepository = skinTestRepository;
        }
        public async Task<MethodResult<SkinTestViewModel>> GetActiveSkinTestAsync()
        {
            var skinTest  = await _skinTestRepository.GetActiveSkinTestAsync();
            var result = _mapper.Map<SkinTestViewModel>(skinTest);
            if (result == null) return new MethodResult<SkinTestViewModel>.Failure("Cannot get skin test!!", StatusCodes.Status500InternalServerError);
            return new MethodResult<SkinTestViewModel>.Success(result);
        }
    }
}
