using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await DB.Images.FindAsync(id);
                if (model != null)
                {
                    DB.Images.Remove(model);
                    await DB.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Image>> Get(int id)
        {
            try
            {
                return await DB.Images.Where(x => x.ProductId == id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
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
