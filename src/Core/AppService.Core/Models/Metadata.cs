using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Models
{
    public class Metadata
    {
       public string Key { get; set; }
       public string Label { get; set; }
       public string HelpText { get; set; }
       public string Value { get; set; }
       public string MetaType { get; set; }
       public string DefaultValue { get; set; }
    }

    
}
