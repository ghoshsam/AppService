using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.Context
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Its collection or DbSet</typeparam>
    /// <typeparam name="IDBCollectionType">It's a d type of Collection Like For MongoDb IMongoCollection</typeparam>
    public interface IDBContext<TEntityCollection>
    {
       IMongoCollection<TEntityCollection> Collection { get; }
    }
    
}
