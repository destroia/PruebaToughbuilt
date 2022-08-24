using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Interface
{
    public interface IProductBI
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAll(int page, string name, int preice, string description, int categoryId = 0);
        Task<bool> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int productId);
    }
}
