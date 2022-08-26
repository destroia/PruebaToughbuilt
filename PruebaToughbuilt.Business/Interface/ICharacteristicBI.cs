using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Business.Interface
{
    public interface ICharacteristicBI
    {
        Task<List<Characteristic>> GetAllByProductId(int id);
        Task<bool> Create(Characteristic characteristic);
        Task<bool> Update(Characteristic characteristic);
        Task<bool> Delete(int id);
    }
}
