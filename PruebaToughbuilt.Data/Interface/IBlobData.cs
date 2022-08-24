using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data.Interface
{
    public interface IBlobData
    {
        Task<string> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName);
    }
}
