using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppService.Infrastructure.Entities;

namespace AppService.Infrastructure.Context
{
    public class AppDBContext:DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            if(Apps.Count () == 0)
                SeedData();
        }
        public virtual DbSet<App> Apps { get; set; }

        private void SeedData()
        {
            var _apps= new List<App>()
            {
                new App() {Id=Guid.NewGuid(),AppName="Shopify" , AppVersion="",Created=DateTime.UtcNow,CreatedBy="SystemSeedDataOwner"},
                new App() {Id=Guid.NewGuid(),AppName="Magento" , AppVersion="2.x",Created=DateTime.UtcNow,CreatedBy="SystemSeedDataOwner"},
                new App() {Id=Guid.NewGuid(),AppName="Sap Business One" , AppVersion="9.0.x",Created=DateTime.UtcNow,CreatedBy="SystemSeedDataOwner"},
                new App() {Id=Guid.NewGuid(),AppName="BigCommerce" , AppVersion="",Created=DateTime.UtcNow,CreatedBy="SystemSeedDataOwner"}
            };
            Apps.AddRange(_apps);
            SaveChanges();
        }
    }
}
