﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }

        public string LastOtp { get; set; }
    }
}
