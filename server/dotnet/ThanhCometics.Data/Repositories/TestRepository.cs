using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;

namespace ThanhCometics.Repository.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ThanhCometicsDBContext _context;
        public TestRepository(ThanhCometicsDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TestTableThanh>> GetAllTestTableThanhsAsync()
        {
            return await _context.TestTableThanhs.ToListAsync();
        }
    }
}
