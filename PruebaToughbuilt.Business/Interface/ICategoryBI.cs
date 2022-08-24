using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Interface
{
    public interface ICategoryBI
    {
        Task<List<Category>> GetAll();
        Task<bool> Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int categoryId);
    }
}
