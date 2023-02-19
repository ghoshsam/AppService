using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Models
{
    public  class CredentialTypeSchema
    {
        public Guid Id { get; set; }    
        public string Name  { get; set; }

        public IEnumerable<Metadata> CredentialAttributes { get; set; }   
    }
}
