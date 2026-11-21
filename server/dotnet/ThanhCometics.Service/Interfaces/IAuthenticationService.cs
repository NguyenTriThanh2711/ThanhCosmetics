using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;

namespace ThanhCometics.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<MethodResult<AccessToken>> AuthenticateAsync(Account account);
        Task<MethodResult<AccessToken>> SigninAsync(LoginRequest request);
        Task<MethodResult<string>> LogoutAsync(string email);
    }
}
