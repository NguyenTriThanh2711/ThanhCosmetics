using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;

namespace ThanhCometics.Service.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<TestTableThanh>> GetAllTestTableThanhsAsync();
    }
}
