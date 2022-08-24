using PruebaToughbuilt.Business.Interface;
using PruebaToughbuilt.Data.Interface;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Business
{
    public class BIProduct : IProductBI
    {
        readonly IProductData Repo;
        public BIProduct(IProductData repo)
        {
            Repo = repo;
        }
        public Task<bool> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll(int page, string name, int preice, string description, int categoryId = 0)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
