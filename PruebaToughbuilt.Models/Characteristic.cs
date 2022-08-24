using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Models
{
    public class Characteristic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(15,ErrorMessage ="Las caracteristicas del producto deben de ser minimo de 4 caracteres maximo de 15 caracteres ",MinimumLength =4)]
        public int Item { get; set; }
    }
}
