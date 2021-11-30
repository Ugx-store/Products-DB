using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        readonly private IBLRepo _bl;

        public ProductImagesController(IBLRepo bl)
        {
            _bl = bl;
        }
        
        // GET: api/<ProductImagesController>
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            List<ProductImage> images = await _bl.GetAllProductImagesAsync(productId);
            if (images.Count != 0)
            {
                return Ok(images);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ProductImagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductImage newImage)
        {
            ProductImage image = await _bl.AddProductImageAsync(newImage);
            return Created("api/[controller]", image);
        }

        // PUT api/<ProductImagesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProductImage updatedImage)
        {
            ProductImage image = await _bl.UpdateProductImageAsync(updatedImage);
            return Ok(image);
        }

        // DELETE api/<ProductImagesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteProductImageAsync(id);
        }
    }
}
