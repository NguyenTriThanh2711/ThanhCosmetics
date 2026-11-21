using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Repository.Models.CustomerModel;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<MethodResult<Customer>> CreateCustomerAsync(SignupRequest request);
        Task<MethodResult<string>> SignupAsync(SignupRequest request);
        Task<MethodResult<Customer>> GetByEmailAsync(string email);
        Task<MethodResult<Customer>> GetByPhoneNumberAsync(string phoneNumber);
        Task<MethodResult<string>> UpdateProfileAsync(Customer cus, ProfileUpdateRequest request);
        Task<MethodResult<string>> RequestPasswordUpdateAsync(string email, PasswordUpdateRequest request);
        Task<MethodResult<string>> RequestPasswordResetAsync(string email);
        Task<MethodResult<string>> VerifyCreatedEmailAsync(Customer cus);
        Task<MethodResult<string>> VerifyAccountAsync(string token);
        Task<MethodResult<string>> VerifyPasswordResetAsync(string token, PasswordResetRequest request);
        Task<MethodResult<string>> RequestResendVerificationEmailAsync(string email);
        Task<MethodResult<Customer>> GetCustomerByIdAsync(int id);
        Task<MethodResult<Account>> GetAccountByEmailAsync(string email);
        Task<MethodResult<ProfileViewModel>> GetProfileAsync(string email);
        Task<MethodResult<string>> UpdateAvatarAsync(string email, string image);
        Task<MethodResult<string>> GetNumberCustomerAsync();
        Task<MethodResult<IEnumerable<CustomerViewModel>>> GetCustomersAsync();
        Task<MethodResult<string>> ActiveCustomerAsync(int userId);
        Task<MethodResult<string>> DeactiveCustomerAsync(int userId);
    }
}
