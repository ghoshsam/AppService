using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.Context
{
    public class MongoContext<TCollection>:IDBContext<TCollection>
    {
        public MongoContext(IConfiguration configuration)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(configuration.GetValue<string>("")));

            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            var client = new MongoClient(settings);
            var database = client.GetDatabase(configuration.GetValue<string>(""));


        }

        public IMongoCollection<TCollection> Collection { get; }
    }
}
