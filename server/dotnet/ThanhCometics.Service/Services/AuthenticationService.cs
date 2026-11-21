using Microsoft.AspNetCore.Http;
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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ICustomerService _customerService;
        public AuthenticationService(
            ITokenGenerator tokenGenerator,
            ICustomerService customerService
            )
        {
            _tokenGenerator = tokenGenerator;
            _customerService = customerService;
        }
        public async Task<MethodResult<AccessToken>> AuthenticateAsync(Account account)
        => await _customerService.GetByEmailAsync(account.Email).Result.Bind<AccessToken>(customer =>
        {
            AccessToken accessToken = new AccessToken();
            if(customer.Account.Role == Constants.USER_ROLE_CUSTOMER)
            {
                accessToken = _tokenGenerator.GenerateAccessTokenToCustomer(customer);
            }
            else
            {
                accessToken = _tokenGenerator.GenerateAccessTokenToOthers(account);
            }
            string refreshToken = _tokenGenerator.GenerateRefreshToken();

            RefreshToken refreshTokenDTO = new() 
            {
                Token = refreshToken,
                AccountId = account.AccountId
            };
            var hasDeleted = 

        })
        public Task<MethodResult<string>> LogoutAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult<AccessToken>> SigninAsync(LoginRequest request)
        {
            return await _customerService.GetAccountByEmailAsync(request.Email).Result.Bind(async account => await _customerService.GetByEmailAsync(request.Email).Result.Bind(async customer =>
            {
                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(request.Password, account.Password);
                if (!isPasswordCorrect) return new MethodResult<AccessToken>.Failure("Invalid email or password", StatusCodes.Status400BadRequest);
                if (account.Role == Constants.USER_ROLE_CUSTOMER)
                {
                    if (customer.Status == Constants.USER_STATUS_INACTIVE)
                    {
                        return new MethodResult<AccessToken>.Failure("Your account is inactive, Please contact within the hotline below!0899353935", StatusCodes.Status400BadRequest);
                    }
                }
                return await AuthenticateAsync(account);
            }));
        }
    }
}
