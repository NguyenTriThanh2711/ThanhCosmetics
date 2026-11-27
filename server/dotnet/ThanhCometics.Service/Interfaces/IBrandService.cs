using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Service.Interfaces
{
    public interface IBrandService
    {
        Task<MethodResult<IEnumerable<BrandViewModel>>> GetBrandsAsync();
    }
}
