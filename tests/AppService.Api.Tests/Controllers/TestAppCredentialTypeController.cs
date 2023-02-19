using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppService.Api.V1.Controllers;
using AppService.Core.Interfaces.Services;
using AppService.Core.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppService.Api.Tests.Controllers
{

    public class TestAppsController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange 
            var mockAppService = new Mock<IAppService>();
            //mockAppService
            //    .Setup(service => service.GetAllAppsAsync())
            //    .ReturnsAsync(new List<App>());

            var SystemUnderTest = new AppsController(mockAppService.Object);
            //Act

             var result = (OkResult) await SystemUnderTest.Get(12);

            //Assert
           result.StatusCode.Should().Be(200);
            //mockAppService.Verify(service=>service.GetAllAppsAsync(), Times.Once());

            //result.Should().BeOfType<OkResult>();
            //var objectResult = (OkResult)result;
            //objectResult.Should().BeOfType<List<App>>();

        }

    }
}
