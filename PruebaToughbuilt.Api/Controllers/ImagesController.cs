using Microsoft.AspNetCore.Http;
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
    public class ImagesController : ControllerBase
    {
        readonly IImageBI BIImage;
        public ImagesController(IImageBI biImage)
        {
            BIImage = biImage;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Image>>> Get(int id)
        {
            return await BIImage.Get(id);
        }
        // POST api/<ImagesController>
        [HttpPost("{id}") ,DisableRequestSizeLimit]
        public async Task<ActionResult> Post(int id)
        {
            IFormFile file = Request.Form.Files[0];
         
            var result = await BIImage.SaveUrl(file.OpenReadStream(), file.ContentType, file.FileName, id);
            if (result )
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<ImagesController>/5
        

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await BIImage.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

            
        }
    }
}
