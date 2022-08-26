using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Models
{
    public class Product
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="El nombre del producto debe ser minimo de 4 caracteres y maximo de 50",MinimumLength =4)]
        public string Name { get; set; }
        [Required]
        [Range(1, 90000000)]
        public long Price { get; set; }
        [Required]
        [Range(1, 9999)]
        public int Stock { get; set; }
        [StringLength(200)]
        public string Description{ get; set; }
        public List<Image> Images { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        [NotMapped]
        public double NumPag { get; set; }
    }
}
