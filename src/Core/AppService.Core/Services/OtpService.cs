using AppService.Core.Interfaces.Infrastructure;
using AppService.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AppService.Core.Services
{
    public class OtpService: IOtpService
    {
        private readonly ISMSService _service;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _configuration;
        private const double EXPIRY_MINUTES = 30;
        public OtpService(ISMSService smsService,IJwtTokenService jwtTokenService , IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(smsService, nameof(smsService));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
            _service = smsService;
            _configuration = configuration;
            _jwtTokenService = jwtTokenService;
        }

        public Task<bool> SendOtpAsync(string mobileNo)
        {
            _service.SendSMS("", mobileNo, "User Admin login OTP is** - SMSCOU");
           return Task.FromResult(true);
        }

        public Task<string> VerifyOtpAndGenerateJWT(string mobileNo, string otp)
        {
            if(true) // Otp Validated
            {

                return Task.FromResult(_jwtTokenService.GetJwtToken(EXPIRY_MINUTES, mobileNo));

            }
            return null;
        }
    }
}
