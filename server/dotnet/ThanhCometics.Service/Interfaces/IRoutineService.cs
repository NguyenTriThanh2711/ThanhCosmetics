using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Service.Interfaces
{
    public interface IRoutineService
    {
        Task<MethodResult<RoutineViewModel>> GetRoutineAsync(int skinTypeId);
        Task<MethodResult<IEnumerable<RoutineGetAllViewModel>>> GetAllRoutineAsync();
    }
}
