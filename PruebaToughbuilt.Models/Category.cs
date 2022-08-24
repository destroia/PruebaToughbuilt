using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15,ErrorMessage ="La Categoria debe ser de minimo 4 caracteres y maximo 15 caracteres ",MinimumLength =4)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
