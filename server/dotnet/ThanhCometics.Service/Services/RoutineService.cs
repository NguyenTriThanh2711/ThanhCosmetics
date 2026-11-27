using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoutineRepository _routineRepository;
        
        public RoutineService(IMapper mapper, IUnitOfWork unitOfWork, IRoutineRepository routineRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _routineRepository = routineRepository;
        }

        public async Task<MethodResult<RoutineViewModel>> GetRoutineAsync(int skinTypeId)
        {
            var rountine = await _routineRepository.GetRoutineBySkinTypeIdAsync(skinTypeId);
            var mappedRoutine = _mapper.Map<RoutineViewModel>(rountine);
            if(mappedRoutine == null) return new MethodResult<RoutineViewModel>.Failure("Something wrong in detected routine", StatusCodes.Status404NotFound);
            return new MethodResult<RoutineViewModel>.Success(mappedRoutine);

        }
        public async Task<MethodResult<IEnumerable<RoutineGetAllViewModel>>> GetAllRoutineAsync()
        {
            var result = await _routineRepository.GetAllRoutineAsync();
            return new MethodResult<IEnumerable<RoutineGetAllViewModel>>.Success(result);
        }
    }
}
