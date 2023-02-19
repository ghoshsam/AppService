using AppService.Api.Request;
using AppService.Api.V1.Controllers;
using AppService.Core.Interfaces.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Api.Tests.Controllers
{
    public class TestAccountCrontroller
    {
        [Fact]
        public async Task SendOtp_OnSuccess_Return200Ok()
        {
            //Arrange
            var mockAccountService = new Mock<IOtpService>();
            mockAccountService
                .Setup(service => service.SendOtpAsync("9330863639"))
                .ReturnsAsync(true);

            var systemUnderTest = new AccountController(mockAccountService.Object);

            var otpRequest=new OTPRequest() { mobileNo= "9330863639" };

            //Act
            var result = (OkObjectResult)await systemUnderTest.GenerateOtp(otpRequest);
            //Assert
            result.StatusCode.Should().Be(200);


        }
    }
}
