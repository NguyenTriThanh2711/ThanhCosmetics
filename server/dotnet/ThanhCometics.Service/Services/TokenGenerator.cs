using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Repository.Models.Configurations;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly AuthenticationConfiguration _configuration;
        public TokenGenerator(IOptions<AuthenticationConfiguration> options)
        {
            _configuration = options.Value;
        }
        private string GenerateToken(string secretKey, string issuer, string audience, DateTime utcExpirationTime, IEnumerable<Claim>? claims)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                DateTime.UtcNow,
                utcExpirationTime,
                credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public AccessToken GenerateAccessTokenToCustomer(Customer customer)
        {
            List<Claim> claims = 
                [
                    new Claim(ClaimTypes.Sid, customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Email, customer.Account.Email),
                    new Claim(ClaimTypes.Role, customer.Account.Role)
                ];
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpiration);
            return new AccessToken
            {
                Token = GenerateToken(
                    _configuration.AccessTokenSecret,
                    _configuration.Issuer,
                    _configuration.Audience,
                    expirationTime,
                    claims),
                ExpirationTime = expirationTime,
            };
        }

        public AccessToken GenerateAccessTokenToOthers(Account account)
        {
            List<Claim> claims =
                [
                    new Claim(ClaimTypes.Sid, account.AccountId.ToString()),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim (ClaimTypes.Role, account.Role)
                ];
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpiration);
            return new AccessToken
            {
                Token = GenerateToken(
                    _configuration.AccessTokenSecret,
                    _configuration.Issuer,
                    _configuration.Audience,
                    expirationTime,
                    claims),
                ExpirationTime = expirationTime,
            };
        }

        public string GenerateEmailVerificationToken(string email)
        {
            List<Claim> claims =
                [
                    new Claim(ClaimTypes.Email,email)
                ];
            DateTime expirationTime = DateTime.UtcNow.AddMinutes( _configuration.AccessTokenExpiration);
            return GenerateToken(
                    _configuration.EmailVerificationSecret,
                    _configuration.Issuer,
                    _configuration.Audience,
                    expirationTime,
                    claims
                );
        }

        public string GeneratePasswordResetToken(string email)
        {
            List<Claim> claims =
                [
                    new Claim(ClaimTypes.Email, email)
                ];
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpiration);
            return GenerateToken(
                    _configuration.PasswordResetSecret,
                    _configuration.Issuer,
                    _configuration.Audience,
                    expirationTime,
                    claims
                );
        }

        public string GenerateRefreshToken()
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.RefreshTokenExpiration);
            return GenerateToken(
                    _configuration.RefreshTokenSecret,
                    _configuration.Issuer,
                    _configuration.Audience,
                    expirationTime, null
                );
        }
    }
}
