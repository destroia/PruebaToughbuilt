using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Models
{
    public class Product
    {   
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="El nombre del producto debe ser minimo de 4 caracteres y maximo de 50",MinimumLength =4)]
        public string Name { get; set; }
        [Required]
        [StringLength(6,ErrorMessage = "El precio debe ser minimo 1 y maximo 999999",MinimumLength =1)]
        public long Price { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "El stock debe ser minimo 1 y maximo 9999", MinimumLength = 1)]
        public int Stock { get; set; }
        public string Description{ get; set; }
        public List<Image> Images { get; set; }
        public List<Characteristic> Characteristics { get; set; }
    }
}
