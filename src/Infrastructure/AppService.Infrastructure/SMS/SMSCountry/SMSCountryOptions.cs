using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.SMS.SMSCountry
{
    public class SMSCountryOptions 
    {
        public string Url { get; set; }
        public string AuthKey { get; init; }=string.Empty;
        public string AuthToken { get; init; } = string.Empty;   
    }
}
