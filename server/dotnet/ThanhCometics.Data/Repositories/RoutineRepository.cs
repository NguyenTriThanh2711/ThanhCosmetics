using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Repositories
{
    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ThanhCometicsDBContext _dbContext;

        public RoutineRepository(IUnitOfWork unitOfWork, ThanhCometicsDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoutineGetAllViewModel>> GetAllRoutineAsync()
        {
            return await Entities
                .Include(r => r.SkinType)
                .Select(r => new RoutineGetAllViewModel
                {
                    RoutineId = r.RoutineId,
                    RoutineName = r.RoutineName,
                    SkinTypeName = r.SkinType.SkinTypeName,
                    SkinTypeId = r.SkinType.SkinTypeId,
                    Status = r.Status
                }).ToListAsync();
        }

        public Task<Routine?> GetRoutineBySkinTypeIdAsync(int skinTypeId)
        {
            return Entities
                .Where(x => x.SkinTypeId == skinTypeId && x.Status == Constants.ROUTINE_ACTIVE)
                .Include(x => x.SkinType)
                .Include(x => x.RoutineDetails)
                    .ThenInclude(rd => rd.RoutineSteps)
                        .ThenInclude(rs => rs.Category)
                            .ThenInclude(c => c.Products)
                                .ThenInclude(p => p.ProductImages)
                .Include(rt => rt.RoutineDetails)
                    .ThenInclude(rd => rd.RoutineSteps)
                        .ThenInclude (rs => rs.Category)
                            .ThenInclude(c => c.Products)
                                .ThenInclude(p => p.ProductIngredients)
                                    .ThenInclude(pi => pi.Ingredient)
                .Include(r => r.RoutineDetails)
                    .ThenInclude(rd => rd.RoutineSteps)
                        .ThenInclude(rs => rs.Category)
                            .ThenInclude(c => c.Products)
                                .ThenInclude(p => p.ProductSkinTypes)
                .FirstOrDefaultAsync();
        }
    }
}
