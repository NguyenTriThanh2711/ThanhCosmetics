using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;

namespace ThanhCometics.Repository.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly ThanhCometicsDBContext _dbContext;

        public RefreshTokenRepository(IUnitOfWork uow, ThanhCometicsDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

        public async Task<bool> CreateAsync(RefreshToken refreshToken)
        {
            try
            {
                Entities.Add(refreshToken);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                return await Task.FromException<bool>(ex);
            }
        }

        public async Task<bool> DeleteAllByAccountIdAsync(int accountId)
        {
            try
            {
                IEnumerable<RefreshToken> resfreshTokens = await Entities.Where(x => x.AccountId == accountId).ToListAsync();
                Entities.RemoveRange(resfreshTokens);
                return await Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                return await Task.FromException<bool>(ex);
            }
        }

        public async Task<RefreshToken?> GetByAccountIdAsync(int accountId)
        {
            try
            {
                var refreshToken = await Entities.FirstOrDefaultAsync(x => x.AccountId == accountId);
                return refreshToken;
            }
            catch (Exception ex) 
            {
                return await Task.FromException<RefreshToken?>(ex);            
            }
        }
    }
}
