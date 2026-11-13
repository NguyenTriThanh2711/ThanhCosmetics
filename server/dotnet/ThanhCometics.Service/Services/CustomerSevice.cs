using ThanhCometics.Common.Helper;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class CustomerSevice : ICustomerService
    {
        public async Task<MethodResult<Customer>> CreateCustomerAsync(SignupRequest request)
        {
            var customer = await _custome
        } 
    }
}
