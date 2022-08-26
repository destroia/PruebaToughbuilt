using Microsoft.AspNetCore.Mvc;
using PruebaToughbuilt.Business.Interface;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaToughbuilt.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CharacteristiciesController : ControllerBase
    {
        readonly ICharacteristicBI BIcharacteristic;
        public CharacteristiciesController(ICharacteristicBI characteristicBI)
        {
            BIcharacteristic = characteristicBI;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Characteristic>>> GetByProductId(int id)
        {
            return await BIcharacteristic.GetAllByProductId(id);
        }
        // POST api/<CharacteristiciesController>
        [HttpPost]
        public async Task<ActionResult<bool> >Post(Characteristic  characteristic)
        {
            var result = await BIcharacteristic.Create(characteristic);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // PUT api/<CharacteristiciesController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Characteristic characteristic)
        {
            var result = await BIcharacteristic.Update(characteristic);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE api/<CharacteristiciesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await BIcharacteristic.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
