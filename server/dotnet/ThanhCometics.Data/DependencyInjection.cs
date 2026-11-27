using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ThanhCometics.Repository.Interface;
using ThanhCometics.Repository.Interfaces;
using ThanhCometics.Repository.Repositories;
using ThanhCometics.Repository;
namespace ThanhCometics.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<ISkinTestRepository, SkinTestRepository>();
            service.AddTransient<IRoutineRepository, RoutineRepository>();
            return service;
        }
    }
}
