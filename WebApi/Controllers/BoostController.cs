using BL;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoostController : ControllerBase
    {
        private readonly IBLRepo _bl;

        public BoostController(IBLRepo bl)
        {
            _bl = bl;
        }

        // GET: api/<BoostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Boost> boosts = await _bl.GetAllBoostedItems();
            if (boosts.Count != 0)
            {
                return Ok(boosts);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<BoostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Boost newBoost)
        {
            Boost boost = await _bl.AddBoostAsync(newBoost);

            if (boost != null)
            {
                return Created("api/[controller]", boost);
            }
            else
            {
                return Created("api/[controller]", "Failed to create Boost");
            }
        }

        // PUT api/<BoostController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]  Boost updatedBoost)
        {
            Boost boost = await _bl.UpdateProductBoost(updatedBoost);
            if (boost == null)
            {
                return Created("api/[controller]", boost);
            }
            else
            {
                return Created("api/[controller]", "Failed to update Boost");
            }
        }
    }
}
