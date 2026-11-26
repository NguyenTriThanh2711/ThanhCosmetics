using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.SkinTestModel;

namespace ThanhCometics.Repository.Interfaces
{
    public interface ISkinTestRepository
    {
        public Task<SkinTest?> GetActiveSkinTestAsync();
        public Task<List<SkinTypeAnswer>> GetSkinTypeAnswersAsync(ListUserAnswerModel list);
    }
}
