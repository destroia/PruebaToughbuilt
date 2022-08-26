using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Interface
{
    public interface IImageBI
    {
        Task<bool> SaveUrl(Stream fileOpenReadStream,string ContentType,string FileName, int productId);
        Task<bool> Delete(int id);
        Task<List<Image>> Get(int id);
    }
}

