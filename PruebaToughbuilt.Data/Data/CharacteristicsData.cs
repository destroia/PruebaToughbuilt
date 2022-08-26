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
    public class CharacteristicsData : ICharacteristicsData
    {
        readonly ContextDBPruebaToughbuilt DB;
        public CharacteristicsData(ContextDBPruebaToughbuilt db)
        {
            DB = db;
        }
        public async  Task<bool> Create(Characteristic characteristic)
        {
            try
            {
                await DB.Characteristics.AddAsync(characteristic);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await DB.Characteristics.FindAsync(id);
                if (model != null)
                {
                    DB.Characteristics.Remove(model);
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

        public async Task<List<Characteristic>> GetAllByProductId(int id)
        {
            try
            {
                return await DB.Characteristics.Where(x => x.ProductId == id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Characteristic characteristic)
        {
            try
            {
                var model = await DB.Characteristics.FindAsync(characteristic.Id);
                if (model != null)
                {
                    model.Item = characteristic.Item;

                    DB.Characteristics.Update(model);
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
