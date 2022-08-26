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
    public class ProductsController : ControllerBase
    {
        readonly IProductBI BIProduct;
        public ProductsController(IProductBI biProduct)
        {
            BIProduct = biProduct;
        }
        
        // GET api/<ProductsController>/5
        [HttpGet("{page}/{name}/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetAll(int page,string name,int categoryId )
        {
            return await BIProduct.GetAll(page, name, categoryId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetByProductId(int id)
        {
            return await BIProduct.GetProductById(id);
        }
        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BIProduct.Create(product);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BIProduct.Update(product);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await BIProduct.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
