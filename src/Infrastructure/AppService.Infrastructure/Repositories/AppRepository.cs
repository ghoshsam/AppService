using AppService.Core.Interfaces.Repositories;
using AppService.Core.Models;
using AppService.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppService.Infrastructure.Repositories
{
    public class AppRepository : IAppRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public AppRepository(AppDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            var dbApps= await _dbContext.Apps.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<App>>(dbApps);
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
