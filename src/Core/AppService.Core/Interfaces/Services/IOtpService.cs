using AppService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Interfaces.Services
{
    public interface IOtpService
    {
        
       Task<bool> SendOtpAsync(string mobileNo);
       Task<string> VerifyOtpAndGenerateJWT (string mobileNo,string otp);
    }
}
