using AppService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAppsAsync();
        Task<User> GetAppByIdAsync(string mobileNo);

        Task<bool> CreateAppAsync(User user);
        Task<bool> DeleteAppAsync(User user);
        Task<User> UpdateAppAsync(User user);

    }
}
