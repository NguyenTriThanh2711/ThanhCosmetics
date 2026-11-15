using ThanhCometics.Common.Helper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
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
        public async Task<MethodResult<Customer>> CreateCustomerAsync(SignupRequest request)
        {
            var createdAccount = await _customerRepository.CreateAccountAsync(request);
            if(createdAccount == null)
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

        public async Task<MethodResult<string>> SignupAsync(SignupRequest request)
        {
            var dupEmailCustomer = await _customerRepository.FindByEmailAsync(request.Email);
            if (dupEmailCustomer != null) return new MethodResult<string>.Failure("Email is already in use", StatusCodes.Status400BadRequest);

            var dupPhoneNumber = await _customerRepository.FindByPhoneNumberAsync(request.PhoneNumber);
            if (dupPhoneNumber != null) return new MethodResult<string>.Failure("Phone number is already in use",StatusCodes.Status400BadRequest);

            // temporary
            var result = await CreateCustomerAsync(request);
            if (result is MethodResult<Customer>.Failure failure) return new MethodResult<string>.Failure(failure.Message, failure.StatusCode);
            return new MethodResult<string>.Success("Signup successful");

        }
    }
}
