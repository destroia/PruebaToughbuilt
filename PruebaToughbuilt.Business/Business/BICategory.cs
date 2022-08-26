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
    public class BICategory : ICategoryBI
    {
        readonly ICategoryData Repo;
        public BICategory(ICategoryData repo)
        {
            Repo = repo;
        }
        public async Task<bool> Create(Category category)
        {
            var result = await Repo.Create(category);
            return result;
        }

        public async Task<bool> Delete(int categoryId)
        {
            var result = await Repo.Delete(categoryId);
            return result;
        }

        public async Task<List<Category>> GetAll()
        {
            return await Repo.GetAll();
             
        }

        public async Task<bool> Update(Category category)
        {
            var result = await Repo.Update(category);
            return result;
        }
    }
}
