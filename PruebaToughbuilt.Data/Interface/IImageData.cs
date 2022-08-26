using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data.Interface
{
    public interface IImageData
    {
        Task<bool> SaveUrl(string url,int productId);
        Task<bool> Delete(int id);
        Task<List<Image>> Get(int id);
    }
}
