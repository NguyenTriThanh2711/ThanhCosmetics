using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ThanhCometics.Repository.ViewModels;
using ThanhCometics.Repository.Models.CustomerModel;
namespace ThanhCometics.Service.Services
{
    public class CustomerSevice : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;
        public CustomerSevice(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Task<MethodResult<string>> ActiveCustomerAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult<Customer>> CreateCustomerAsync(SignupRequest request)
        {
            var createdAccount = await _customerRepository.CreateAccountAsync(request);
            if (createdAccount == null)
            {
                return new MethodResult<Customer>.Failure("False to create new account", StatusCodes.Status500InternalServerError);
            }
            var customer = _mapper.Map<Customer>(request);
            customer.AccountId = createdAccount.AccountId;

            var createdCustomer = await _customerRepository.CreateCustomerAsync(customer);
            if (createdCustomer == null)
            {
                return new MethodResult<Customer>.Failure("False to create new customer", StatusCodes.Status500InternalServerError);
            }

            return new MethodResult<Customer>.Success(createdCustomer);
        }

        public Task<MethodResult<string>> DeactiveCustomerAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult<Account>> GetAccountByEmailAsync(string email)
        {
            var account = await _customerRepository.GetAccountByEmailAsync(email);
            if (account == null) return new MethodResult<Account>.Failure("There is no account found!", StatusCodes.Status404NotFound);
            return new MethodResult<Account>.Success(account);
        }

        public async Task<MethodResult<Customer>> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.FindByEmailAsync(email);
            if (customer == null) return new MethodResult<Customer>.Failure("There is no accout with this email!", StatusCodes.Status404NotFound);
            return new MethodResult<Customer>.Success(customer);
        }

        public Task<MethodResult<Customer>> GetByPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<Customer>> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<IEnumerable<CustomerViewModel>>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<string>> GetNumberCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult<ProfileViewModel>> GetProfileAsync(string email)
        {
            var result = await _customerRepository.FindByEmailAsync(email);
            if (result == null) return new MethodResult<ProfileViewModel>.Failure("Fail to get profile!!",StatusCodes.Status500InternalServerError);
            return new MethodResult<ProfileViewModel>.Success(_mapper.Map<ProfileViewModel>(result));
        }

        public Task<MethodResult<string>> RequestPasswordResetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<string>> RequestPasswordUpdateAsync(string email, PasswordUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<string>> RequestResendVerificationEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult<string>> SignupAsync(SignupRequest request)
        {
            var dupEmailCustomer = await _customerRepository.FindByEmailAsync(request.Email);
            if (dupEmailCustomer != null) return new MethodResult<string>.Failure("Email is already in use", StatusCodes.Status400BadRequest);

            var dupPhoneNumber = await _customerRepository.FindByPhoneNumberAsync(request.PhoneNumber);
            if (dupPhoneNumber != null) return new MethodResult<string>.Failure("Phone number is already in use",StatusCodes.Status400BadRequest);

            // temporary
            var result = await CreateCustomerAsync(request);
            if (result is MethodResult<Customer>.Failure failure) return new MethodResult<string>.Failure("False to create account", failure.StatusCode);
            return new MethodResult<string>.Success("Signup successful");

        }

        public Task<MethodResult<string>> UpdateAvatarAsync(string email, string image)
        {
            throw new NotImplementedException();
        }
        public async Task<MethodResult<string>> RequestUpdateProfileAsync(string email, ProfileUpdateRequest request) 
            => await GetByEmailAsync(email).Result.Bind(async cus => await UpdateProfileAsync(cus, request));
        public async Task<MethodResult<string>> UpdateProfileAsync(Customer cus, ProfileUpdateRequest request)
        {
            var result = await _customerRepository.UpdateProfileAsync(cus, request);
            if(!result) return new MethodResult<string>.Failure("Fail to update profile", StatusCodes.Status500InternalServerError);
            return new MethodResult<string>.Success("Update profile successfully!!");
        }

        public Task<MethodResult<string>> VerifyAccountAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<string>> VerifyCreatedEmailAsync(Customer cus)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResult<string>> VerifyPasswordResetAsync(string token, PasswordResetRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
