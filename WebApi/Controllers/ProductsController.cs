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
    public class ProductsController : ControllerBase
    {
        readonly private IBLRepo _bl;

        public ProductsController(IBLRepo bl)
        {
            _bl = bl;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Product> products = await _bl.GetAllProductsAsync();
            if(products.Count != 0)
            {
                return Ok(products);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/<ProductsController>/kimuli
        [HttpGet("user-products/{username}")]
        public async Task<IActionResult> GetUserProducts(string username)
        {
            List<Product> products = await _bl.GetAllUserProductsAsync(username);
            if (products.Count != 0)
            {
                return Ok(products);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _bl.GetOneProductAsync(id);
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product newProduct)
        {
            Product product = await _bl.AddProductAsync(newProduct);
            return Created("api/[controller]", product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product updatedProduct)
        {
            Product product = await _bl.UpdateProductAsync(updatedProduct);
            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteProductAsync(id);
        }
    }
}
