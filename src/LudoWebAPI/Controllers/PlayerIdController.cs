using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoWebAPI.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebAPI.Controllers
{
    [Route("api/ludogame/{id}/player/{id}")]
    [ApiController]
    public class PlayerIdController : ControllerBase
    {
        

        // GET: api/PlayerId
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            

        }

        // PUT: api/PlayerId
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Playerid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
