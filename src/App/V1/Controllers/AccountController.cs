using AppService.Api.Request;
using AppService.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IOtpService _otpService;
        public AccountController(IOtpService otpService)
        {
            ArgumentNullException.ThrowIfNull(otpService, nameof(otpService));
            _otpService = otpService;
        }

        [HttpPost("generateotp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GenerateOtp(OTPRequest request)
        {
            var success = await _otpService.SendOtpAsync(request.mobileNo);
            return success? Ok("") : Unauthorized();
        }
        [HttpPost("varifyOtp")]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VerifyOtp(VerifyOTORequest request)
        {
            var token = await _otpService.VerifyOtpAndGenerateJWT(request.mobileNo, request.otp);
            return token != null? Ok(token) : Unauthorized();
        }
    }
}
