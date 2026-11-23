using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;

namespace ThanhCometics.Service.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<MethodResult<AccessToken>> RefreshTokenAsync(string token);
        Task<MethodResult<RefreshToken>> GetByAccountIdAsync(int id);
    }
}
