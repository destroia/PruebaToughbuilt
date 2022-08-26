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
        public async Task<Product> Create(Product product)
        {
            var result = await Repo.Create(product);
            return result;
        }

        public async Task<bool> Delete(int productId)
        {
            var result = await Repo.Delete(productId);
            return result;
        }

        public async Task<List<Product>> GetAll(int page, string name, int categoryId = 0)
        {
            var result = await Repo.GetAll(page, name, categoryId);
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await Repo.GetProductById(id);
        }

        public async Task<bool> Update(Product product)
        {
            var result = await Repo.Update(product);
            return result;
        }
    }
}
