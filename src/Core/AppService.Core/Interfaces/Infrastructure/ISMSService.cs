using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Interfaces.Infrastructure
{
    public interface ISMSService
    {
        Task<string> SendSMS(string from , string to, string message);
    }
}
