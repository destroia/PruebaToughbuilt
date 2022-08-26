using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data.Interface
{
    public interface IProductData
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAll(int page, string name, int categoryId = 0);
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int productId);
    }
}
