using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }
        public async Task<IEnumerable<TestTableThanh>> GetAllTestTableThanhsAsync()
        {
            return await _testRepository.GetAllTestTableThanhsAsync();
        }
    }
}
