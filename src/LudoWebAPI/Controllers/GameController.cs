using System;
using System.Collections.Generic;
using LudoGameEngine;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LudoWebAPI.Game;

namespace LudoWebAPI.Controllers
{
    [Route("api/ludogame")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private IGameContainer _activeGames;

        public void gameController(IGameContainer activeGames)
        {
            _activeGames = activeGames;
        }

        // GET: api/Game
        /// <summary>
        /// Get all active games
        /// </summary>
        /// <returns>List of game IDs</returns>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _activeGames.GetAllGameIds();
        }

        // Post: api/Game/
        /// <summary>
        /// Create a new game
        /// </summary>
        /// <returns>A new game</returns>
        [HttpPost]
        public int Post()
        {
            
            int gameID = _activeGames.GetAllGameIds().Max() +1;
            _activeGames.CreateGame(gameID);

            return gameID;
        }



    }
}
