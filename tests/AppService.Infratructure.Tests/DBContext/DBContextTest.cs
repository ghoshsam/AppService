using AppService.Infrastructure.Context;
using AppService.Core.Interfaces;
using Moq;
using FluentAssertions;
using MongoDB.Driver;

namespace AppService.Infratructure.Tests.DBContext
{
    public class DBContextTest
    {
        [Fact]
        public void MongoDbContextTest()
        {
            //Arrange
            IDBContext<Mock<IEntity>> dbContext = new MongoContext<Mock<IEntity>>();
            //Act
            var result = dbContext.Collection;
            //Assert
            result.Should().BeOfType<IMongoCollection<IEntity>>();


           
        }
    }
}