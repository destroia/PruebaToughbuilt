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
    public class CategoryData : ICategoryData
    {
        readonly ContextDBPruebaToughbuilt DB;
        public CategoryData(ContextDBPruebaToughbuilt db)
        {
            DB = db;
        }
        public async Task<bool> Create(Category category)
        {
            try
            {
                await DB.Categories.AddAsync(category);
                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int categoryId)
        {
            try
            {
                var result = await DB.Products.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
                if (result == null)
                {
                    var model = await DB.Categories.FindAsync(categoryId);
                    if (model != null)
                    {
                        DB.Categories.Remove(model);
                        await DB.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                return await DB.Categories.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Category category)
        {
            try
            {
                var model = await DB.Categories.FindAsync(category.Id);
                if (model != null)
                {
                    model.Name = category.Name;
                    DB.Categories.Update(model);
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
    }
}
