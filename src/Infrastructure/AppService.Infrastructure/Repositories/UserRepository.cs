using AppService.Core.Interfaces.Repositories;
using AppService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> CreateAppAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAppAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAppsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAppByIdAsync(string mobileNo)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAppAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
