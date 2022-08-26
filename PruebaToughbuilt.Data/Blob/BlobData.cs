using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using PruebaToughbuilt.Data.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data.Blob
{
    public class BlobData : IBlobData
    {
        readonly BlobServiceClient _blobServiceClient;
        public BlobData(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<string> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName)
        {
            try
            {
                fileName =  Guid.NewGuid() + fileName;
                var containerClient = GetContainerClient(blobContainerName);
                var blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
                return blobClient.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
    }
}
