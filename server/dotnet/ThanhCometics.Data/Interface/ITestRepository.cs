using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;

namespace ThanhCometics.Repository.Interface
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestTableThanh>> GetAllTestTableThanhsAsync();
    }
}
