using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.SMS.SMSCountry
{
    internal class MessageBody
    {
        public string Text  { get; set; }
        public string Number { get; set; }
        public string SenderId { get; set; }
        public string Tool { get; } = "API";


    }
}
