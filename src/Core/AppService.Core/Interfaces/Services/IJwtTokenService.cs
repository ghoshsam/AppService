using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Interfaces.Services
{
    public interface IJwtTokenService
    {
        public string GetJwtToken(double expiryminutes, string mobileno);
        public bool ValidateToken(string token);
    }
}
