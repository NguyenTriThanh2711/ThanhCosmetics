using ThanhCometics.Common.Helper;
using ThanhCometics.Repository.Models.AuthenticationModel;

namespace ThanhCometics.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<MethodResult<String>> SignupAsync(SignupRequest request);
    }
}
