using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenValidator _tokenValidator;
        private readonly ICustomerService _customerService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public RefreshTokenService(IAuthenticationService authenticationService, ITokenValidator tokenValidator, ICustomerService customerService, IRefreshTokenRepository refreshTokenRepository)
        {
            _authenticationService = authenticationService;
            _tokenValidator = tokenValidator;
            _customerService = customerService;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<MethodResult<AccessToken>> RefreshTokenAsync(string token)
            => await _tokenValidator.GetEmailFromExpiredAccesstoken(token)
            .Bind(email => _customerService.GetAccountByEmailAsync(email)).Result
            .Bind(account => GetByAccountIdAsync(account.AccountId).Result.Bind(async refreshTK =>
            {
                var isValid = _tokenValidator.ValidateRefreshToken(refreshTK.Token);
                if (!isValid) return new MethodResult<AccessToken>.Failure("Invalid refresh token", StatusCodes.Status401Unauthorized);
                return await _authenticationService.AuthenticateAsync(account);
            }));
        public async Task<MethodResult<RefreshToken>> GetByAccountIdAsync(int accountId)
        {
            var refreshToken = await _refreshTokenRepository.GetByAccountIdAsync(accountId);
            if (refreshToken == null ) return new MethodResult<RefreshToken>.Failure("None refresh token found by this account", StatusCodes.Status401Unauthorized);
            return  new MethodResult<RefreshToken>.Success(refreshToken);
        }

    }
}
