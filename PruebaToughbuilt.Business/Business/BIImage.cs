using PruebaToughbuilt.Business.Interface;
using PruebaToughbuilt.Data.Interface;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Business
{
    public class BIImage : IImageBI
    {
        readonly IImageData Repo;
        readonly IBlobData Blob;
        public BIImage(IImageData repo, IBlobData blob)
        {
            Repo = repo;
            Blob = blob;
        }
        public async  Task<bool> Delete(int id)
        {
            var result = await Repo.Delete(id);
            return result;
        }

        public async Task<List<Image>> Get(int id)
        {
            return await Repo.Get(id);
        }

        public async Task<bool> SaveUrl(Stream fileOpenReadStream, string ContentType, string FileName,int productId)
        {
            string url = await Blob.UploadFileBlobAsync("products", fileOpenReadStream, ContentType, FileName);
            if (url != "")
            {
                var result  = await Repo.SaveUrl(url, productId);
                return true;
            }
            return false; 
        }
    }
}
