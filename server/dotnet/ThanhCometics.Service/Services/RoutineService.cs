using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository;
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

        public Task<MethodResult<RoutineViewModel>> GetRoutineAsync(int skinTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
