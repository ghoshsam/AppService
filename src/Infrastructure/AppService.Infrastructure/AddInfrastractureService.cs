using AppService.Core.Interfaces.Repositories;
using AppService.Infrastructure.Context;
using AppService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastractureExtentiuons
    {

        public static IServiceCollection AddInfrastracture(this IServiceCollection services)
        {
            services.AddScoped<IAppRepository, AppRepository>();
            services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("Apps"));
            services.AddScoped<DbContext, AppDBContext>();
            return services;
        }
    }
}
