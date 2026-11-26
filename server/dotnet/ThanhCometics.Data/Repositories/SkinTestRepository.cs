using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.Models.SkinTestModel;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Repositories
{
    public class SkinTestRepository : Repository<SkinTest>, ISkinTestRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ThanhCometicsDBContext _dbContext;
        public SkinTestRepository(IUnitOfWork unitOfWork, IMapper mapper, ThanhCometicsDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        } 
        public async Task<SkinTest?> GetActiveSkinTestAsync()
        {
            return  await Entities.Include(x => x.SkinTypeQuestions)
                .ThenInclude(x => x.SkinTypeAnswers)
                .FirstOrDefaultAsync(x => x.Status == Constants.SKIN_TEST_ACTIVE);
        }
        
        public Task<List<SkinTypeAnswer>> GetSkinTypeAnswersAsync(ListUserAnswerModel list)
        {
            return _dbContext.SkinTypeAnswers
                .Where(x => list.ListUserAnswer.Contains(x.SkinTypeAnswerId))
                .Include(x => x.SkinTypeAnswerSkinTypes)
                .ThenInclude(x => x.SkinType)
                .ToListAsync();
        }
    }
}
