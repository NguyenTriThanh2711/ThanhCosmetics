using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Interfaces
{
    public interface IRoutineRepository
    {
        public Task<Routine?> GetRoutineBySkinTypeIdAsync(int id);
        public Task<IEnumerable<RoutineGetAllViewModel>> GetAllRoutineAsync();
    }
}
