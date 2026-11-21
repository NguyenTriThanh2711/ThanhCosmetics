using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;

namespace ThanhCometics.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<bool> CreateAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByAccountIdAsync(int accountId);
        Task<bool> DeleteAllByAccountIdAsync(int accountId);
    }
}
