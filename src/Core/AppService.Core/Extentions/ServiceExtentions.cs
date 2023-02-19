using AppService.Core.Interfaces.Services;
using AppService.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Extentions.DependencyInjection
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAppService, AppServices>();
            services.AddScoped<IOtpService, OtpService>();
            return services;

        }
    }
}
