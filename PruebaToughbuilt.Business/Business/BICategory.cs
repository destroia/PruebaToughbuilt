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
        public Task<bool> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
