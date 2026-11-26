using AutoMapper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Models.AuthenticationModel;
using Microsoft.EntityFrameworkCore;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Repository.Models.CustomerModel;

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

        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            return await _dbContext.Accounts.Include(x => x.Customer).FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id) => await Entities.Include(x => x.Account).FirstOrDefaultAsync(c => c.AccountId == id);
   

        public Task<IEnumerable<CustomerViewModel>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNumberCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsEmailTaken(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var customerInDB = await Entities.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
            if (customerInDB == null) return await Task.FromResult(false);
            Entities.Entry(customerInDB).CurrentValues.SetValues(customer);
            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateProfileAsync(Customer customer, ProfileUpdateRequest request)
        {
            try
            {
                customer.FullName = !string.IsNullOrEmpty(request.FullName) ? request.FullName : customer.FullName;
                customer.PhoneNumber = !string.IsNullOrEmpty(request.PhoneNumber) ? request.PhoneNumber : customer.PhoneNumber;
                customer.Birthday = request.Birthday.HasValue ? request.Birthday : customer.Birthday;
                customer.Image = !string.IsNullOrEmpty(request.Image) ? request.Image : customer.Image;
                return await UpdateCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return await Task.FromResult(false);
            }
        }
    }
}
