using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Models.Configurations;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.Service.Services
{
    public class TokenValidator : ITokenValidator
    {
        private readonly AuthenticationConfiguration _configuration;
        public TokenValidator(IOptions<AuthenticationConfiguration> options)
        {
            _configuration = options.Value;
        }
        public ClaimsPrincipal? Validate(string secretKey, string token, bool validateLifeTime)
        {
            TokenValidationParameters validationParameters = new()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidIssuer = _configuration.Issuer,
                ValidAudience = _configuration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = validateLifeTime,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var cp = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return cp;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public MethodResult<string> GetEmailFromExpiredAccesstoken(string token)
        {
            var cp = Validate(_configuration.AccessTokenSecret, token, false);
            var email = cp?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if(email == null) return new MethodResult<string>.Failure("Invalid token",StatusCodes.Status400BadRequest);
            return new MethodResult<string>.Success(email);
        }

        public MethodResult<string> ValidateEmailVerificationToken(string token)
        {
            throw new NotImplementedException();
        }

        public MethodResult<string> ValidatePasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool ValidateRefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
