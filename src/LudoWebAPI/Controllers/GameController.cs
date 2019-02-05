using System;
using System.Collections.Generic;
using LudoGameEngine;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LudoWebAPI.Game;
using LudoWebAPI.Models;
namespace LudoWebAPI.Controllers
{
    [Route("api/ludogame")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private IGameContainer _activeGames;

        public void gameController(IGameContainer activeGames)
        {
            _activeGames = new GameContainer(new Diece());
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

        /// <summary>
        /// visar information om spelet
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        // GET: api/GameId/5
        [HttpGet("{gameid}")]
        public GameModel Get(int gameId)
        {
            LudoGame game = _activeGames[gameId];
            int numberOfPlayers = game.GetPlayers().Count();
            var currentPlayer = game.GetCurrentPlayer();
            return new GameModel()
            {
                GameId = gameId,
                CurrentPlayerId = currentPlayer == null ? 0 : currentPlayer.PlayerId,
                NumberOfPlayers = numberOfPlayers,
                State = game.GetGameState().ToString()
            };
        }
        
        /// <summary>
        /// ändrar spelpjäsens position
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/GameId/5
        [HttpPut("{gameid}")]
        public void PutGame(int gameId)
        {


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{gameid}")]
        public void Delete(int gameId)
        {
            _activeGames.DeleteGame(gameId);
        }
    }
}
