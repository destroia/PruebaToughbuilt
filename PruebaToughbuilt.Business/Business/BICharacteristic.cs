using PruebaToughbuilt.Business.Interface;
using PruebaToughbuilt.Data.Interface;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Business
{
    public class BICharacteristic : ICharacteristicBI
    {
        readonly ICharacteristicsData Repo;
        public BICharacteristic(ICharacteristicsData repo)
        {
            Repo = repo;
        }
        public async Task<bool> Create(Characteristic characteristic)
        {
            var result = await Repo.Create(characteristic);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await Repo.Delete(id);
        }

        public async Task<List<Characteristic>> GetAllByProductId(int id)
        {
            return await Repo.GetAllByProductId(id);
        }

        public async Task<bool> Update(Characteristic characteristic)
        {
            var result = await Repo.Update(characteristic);
            return result;
        }
    }
}
