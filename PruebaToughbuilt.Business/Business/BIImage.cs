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
        readonly IBlobData blob;
        public BIImage(IImageData repo)
        {
            Repo = repo;
        }
        public async  Task<bool> Delete(Image image)
        {
            var result = await Repo.Delete(image);
            return result;
        }

        public async Task<bool> SaveUrl(Stream fileOpenReadStream, string ContentType, string FileName,int productId)
        {
            string url = await blob.UploadFileBlobAsync("Products", fileOpenReadStream, ContentType, FileName);
            if (url != "")
            {
                var result  = await Repo.SaveUrl(url, productId);
                return true;
            }
            return false; 
        }
    }
}
