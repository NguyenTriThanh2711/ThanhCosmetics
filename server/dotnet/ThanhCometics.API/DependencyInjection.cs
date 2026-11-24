using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ThanhCometics.Repository.Models.Configurations;

namespace ThanhCometics.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection service)
        {
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                var serviceProvider = service.BuildServiceProvider();
                var authenticationConfigration = serviceProvider.GetRequiredService<IOptions<AuthenticationConfiguration>>().Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfigration.AccessTokenSecret)),
                    ValidIssuer = authenticationConfigration.Issuer,
                    ValidAudience = authenticationConfigration.Audience,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            return service;
        }
    }
}
