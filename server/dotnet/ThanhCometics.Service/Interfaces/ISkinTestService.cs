using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Models.SkinTestModel;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Service.Interfaces
{
    public interface ISkinTestService
    {
        Task<MethodResult<SkinTestViewModel>> GetActiveSkinTestAsync();
        Task<MethodResult<SkinTestResultViewModel>> DetermineSkinTypeAsync(int userId, ListUserAnswerModel list);
    }
}
