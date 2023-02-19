using AppService.Core.Interfaces.Infrastructure;
using AppService.Core.Interfaces.Repositories;
using AppService.Infrastructure.Context;
using AppService.Infrastructure.Repositories;
using AppService.Infrastructure.SMS.SMSCountry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastractureExtentiuons
    {

        public static IServiceCollection AddInfrastracture(this IServiceCollection services , IConfiguration configuration)
        {
          
            services.Configure<SMSCountryOptions>(configuration.GetSection("SMSCountryOptions"));
            services.AddScoped<ISMSService, SMSService>();
            services.AddScoped<IAppRepository, AppRepository>();
            services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("Apps"));
            services.AddScoped<DbContext, AppDBContext>();
            return services;
        }
    }
}
