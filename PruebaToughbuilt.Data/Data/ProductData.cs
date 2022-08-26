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
    public class ProductData : IProductData
    {
        readonly ContextDBPruebaToughbuilt DB;
        public ProductData(ContextDBPruebaToughbuilt db)
        {
            DB = db;
        }
        public async  Task<Product> Create(Product product)
        {
            try
            {
                await DB.Products.AddAsync(product);
                await DB.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                var model = await DB.Products.FindAsync(productId);
                if (model != null)
                {
                    DB.Products.Remove(model);
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

        public async Task<List<Product>> GetAll(int page, string name, int categoryId = 0)
        {
            try
            {// esto se tiene Que Cambiar Por un SP 
                double count = await DB.Products.Where(x => 

               (((x.Name.Contains("") && name == "0") || ((x.Name.Contains(name) && name != "0") ))) && 

                     ((x.CategoryId.ToString().Contains("") && categoryId == 0 ) || (x.CategoryId == categoryId && categoryId != 0)))
              // (categoryId != 0 && x.CategoryId && x.CategoryId == categoryId)
                    .CountAsync();

                var result =  await DB.Products.Where(x =>

               (((x.Name.Contains("") && name == "0") || ((x.Name.Contains(name) && name != "0") ))) &&

                     ((x.CategoryId.ToString().Contains("") && categoryId == 0 ) || (x.CategoryId == categoryId && categoryId != 0)))

                    .OrderBy(x => x.Id)
                    .Skip(10 * page).Take(10)
                    .ToListAsync();

                if (result.Count > 0)
                {
                    var ids = result.Select(x => x.Id).ToList();

                    var imag = await DB.Images.Where(x => ids.Contains(x.ProductId)).ToListAsync();

                    result.ForEach(x => x.Images = imag.Where(c => c.ProductId == x.Id).ToList());
                }
                
                result.ForEach(x => x.NumPag = Math.Ceiling(count / 10));

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var result = await DB.Products.FindAsync(id);
                if (result != null)
                {
                    result.Characteristics = await DB.Characteristics.Where(x => x.ProductId == id).ToListAsync();
                    result.Images = await DB.Images.Where(x => x.ProductId == id).ToListAsync();
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                var model = await DB.Products.FindAsync(product.Id);
                if (model != null)
                {
                    model.Name = product.Name;
                    model.Price = product.Price;
                    model.Stock = product.Stock;
                    model.Description = product.Description;
                    DB.Products.Update(model);
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
