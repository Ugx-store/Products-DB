using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        readonly private IBLRepo _bl;

        public LikesController(IBLRepo bl)
        {
            _bl = bl;
        }

        // GET: api/<LikesController>/5
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            List<Like> likes = await _bl.GetAllLikesAsync(productId);
            if (likes.Count != 0)
            {
                return Ok(likes);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<LikesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Like newLike)
        {
            Like like = await _bl.AddLikeAsync(newLike);
            return Created("api/[controller]", like);
        }

        // DELETE api/<LikesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteLikeAsync(id);
        }

        // DELETE api/<LikesController>/5
        [HttpDelete("deleteLikes/{id}")]
        public async Task DeleteLikes(int id)
        {
            await _bl.DeleteLikesAsync(id);
        }
    }
}
