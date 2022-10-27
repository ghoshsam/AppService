using AppService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Interfaces.Services
{
    public interface IAppService
    {
        Task<IEnumerable<App>> GetAllAppsAsync();
        Task<App> GetAppByIdAsync(int Id);

        Task<bool> CreateAppAsync(App app);
        Task<bool> DeleteAppAsync(App app);
        Task<App> UpdateAppAsync(App app);
    }
}
