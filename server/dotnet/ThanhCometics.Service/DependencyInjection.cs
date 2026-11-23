using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Service.Interfaces;
using ThanhCometics.Service.Services;

namespace ThanhCometics.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddTransient<ICustomerService, CustomerSevice>();
            service.AddTransient<ITokenGenerator, TokenGenerator>();
            service.AddTransient<ITokenValidator, TokenValidator>();
            service.AddTransient<IRefreshTokenService, RefreshTokenService>();
            return service;
        }
    }
}
