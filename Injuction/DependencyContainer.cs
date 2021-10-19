using DataAccess.AdoNet;
using Domain.Abstract.Entity.Logic;
using Domain.Abstract.Repository;
using Domain.Entity.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Injuction
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<ILeadSourceLogic, LeadSourceLogic>();
            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();
            return services;
        }
    }
}
