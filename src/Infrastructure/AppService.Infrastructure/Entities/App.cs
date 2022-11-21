using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Infrastructure.Entities
{
    public class App
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string AppName { get; set; }
        [Required]
        public string AppVersion { get; set; }

        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string CreatedBy { get; set; }


    }
}
