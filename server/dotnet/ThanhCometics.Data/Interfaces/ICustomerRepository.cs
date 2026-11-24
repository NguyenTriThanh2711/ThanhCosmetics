using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Repository.Models.CustomerModel;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Account> CreateAccountAsync(SignupRequest request);
        Task<Customer?> CreateCustomerAsync(Customer customer);
        Task<Customer?> FindByEmailAsync(string email);
        Task<Customer?> FindByPhoneNumberAsync(string phoneNumber);
        Task<bool> UpdateCustomerAsync(Customer customer);
        bool IsEmailTaken(string email);
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<bool> UpdateProfileAsync(Customer customer, ProfileUpdateRequest request);
        Task<Account?> GetAccountByEmailAsync(string email);
        Task<int> GetNumberCustomerAsync();
        Task<IEnumerable<CustomerViewModel>> GetCustomersAsync();
    }
}
