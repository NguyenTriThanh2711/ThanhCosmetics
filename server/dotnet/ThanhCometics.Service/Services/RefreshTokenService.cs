using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenValidator _tokenValidator;
        private readonly ICustomerService _customerService;
        public RefreshTokenService(IAuthenticationService authenticationService, ITokenValidator tokenValidator, ICustomerService customerService)
        {
            _authenticationService = authenticationService;
            _tokenValidator = tokenValidator;
            _customerService = customerService;
        }
        public Task<MethodResult<AccessToken>> RefreshTokenAsync(string token) 
            => _tokenValidator.GetEmailFromExpiredAccesstoken(token)
            .Bind(email => _customerService.GetAccountByEmailAsync(email)).Result
            .Bind(account => )
        public Task<MethodResult<RefreshToken>> GetByCustomerIdAsync(string customerId)
        {
            throw new NotImplementedException();
        }

    }
}
