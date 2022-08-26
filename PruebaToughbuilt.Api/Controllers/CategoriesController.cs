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
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryBI BICategory;
        public CategoriesController(ICategoryBI categoryBI)
        {
            BICategory = categoryBI;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await BICategory.GetAll();
        }

       

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BICategory.Create(category);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BICategory.Update(category);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BICategory.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
