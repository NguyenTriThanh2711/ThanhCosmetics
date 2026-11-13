using AutoMapper;
using BeautySCProject.Data.Models.AuthenticationModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;

namespace ThanhCometics.Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ThanhCometicsDBContext _dbContext;
        private IMapper _mapper;
        public CustomerRepository(IUnitOfWork unitOfWork, ThanhCometicsDBContext dbContext, IMapper mapper) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<Account> CreateAccountAsync(SignupRequest request)
        {
            return new Account();
        }

        public Task<Customer?> CreateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> FindByPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
