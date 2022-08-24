using PruebaToughbuilt.Data.Interface;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data.Data
{
    public class ImageData : IImageData
    {
        readonly ContextDBPruebaToughbuilt DB;
        public ImageData(ContextDBPruebaToughbuilt db)
        {
            DB = db;
        }
        public async Task<bool> Delete(Image image)
        {
            try
            {
                DB.Images.Remove(image);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SaveUrl(string url, int productId)
        {
            try
            {
                await DB.Images.AddAsync(new Image()
                { Id = 0, ProductId = productId, Url = url });
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
