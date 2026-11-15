using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Models.AuthenticationModel;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Account> CreateAccountAsync(SignupRequest request)
        {
            try
            {
                var account = _mapper.Map<Account>(request);
                await _dbContext.Accounts.AddAsync(account);
                await _unitOfWork.SaveChangesAsync();
                return account;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Customer?> CreateCustomerAsync(Customer customer)
        {
            try
            {
                Entities.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Customer?> FindByEmailAsync(string email)
        {
            return await Entities.Include(x => x.Account).Include(x => x.SkinType).FirstOrDefaultAsync(u => u.Account.Email == email);
        }

        public async Task<Customer?> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await Entities.Include(x => x.Account).FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
