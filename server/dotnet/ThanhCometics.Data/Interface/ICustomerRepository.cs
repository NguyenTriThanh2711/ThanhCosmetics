using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;

namespace ThanhCometics.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Account> CreateAccountAsync(SignupRequest request);
        Task<Customer?> CreateCustomerAsync(Customer customer);
        Task<Customer?> FindByEmailAsync(string email);
        Task<Customer?> FindByPhoneNumberAsync(string phoneNumber);
    }
}
