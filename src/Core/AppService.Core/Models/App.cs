using System.ComponentModel.DataAnnotations;

namespace AppService.Core.Models
{
    public class App
    {
        public Guid Id { get; set; }    
        [Required]
        [StringLength(100)]
        public string AppName { get; set; }
        [Required]
        [StringLength(50)]
        public string AppVersion { get; set; }
        [Required]
        public string AppDescrioptions{ get; set; }
       
    }
}
