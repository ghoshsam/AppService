using AppService.Core.Interfaces.Repositories;
using AppService.Core.Interfaces.Services;
using AppService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Services
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;
        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository?? throw new ArgumentNullException(nameof(appRepository));
        }
        public Task<bool> CreateAppAsync(App app)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAppAsync(App app)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<App>> GetAllAppsAsync()
        {
           return await _appRepository.GetAllAppsAsync();
        }

        public Task<App> GetAppByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<App> UpdateAppAsync(App app)
        {
            throw new NotImplementedException();
        }
    }
}
