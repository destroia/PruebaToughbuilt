using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Models
{
    public class Image
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(200,MinimumLength =4)]
        public string Url { get; set; }
    }
}
