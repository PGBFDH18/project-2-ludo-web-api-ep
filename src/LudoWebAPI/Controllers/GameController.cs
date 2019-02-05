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

        private readonly ILudoGame _LudoGame;
        private readonly IGameContainer _games;


        public GameController(ILudoGame ludoGame, IGameContainer games)
        {
            _games = games;
            _LudoGame = ludoGame;
        }


        // Post: api/Game/
        /// <summary>
        /// Create a new game
        /// </summary>
        /// <returns>A new game</returns>
        [HttpPost]
        public int PostGame()
        {
            int gameID = _games.GetAllGameIds().Max() + 1;
            _games.CreateGame(gameID);

            return gameID;
        }

        // GET: api/Game
        /// <summary>
        /// Get all games
        /// </summary>
        /// <returns>List of game IDs</returns>
        [HttpGet]
        public IEnumerable<int> GetGames()
        {
            return _games.GetAllGameIds();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{gameid}")]
        public void DeleteGame(int gameId)
        {
            _games.DeleteGame(gameId);
        }

        /// <summary>
        /// visar pjäsernas positioner
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        // GET: api/GameId/5
        [HttpGet("{gameid}")]
        public GameModel Get(int gameId)
        {
            LudoGame game = _games[gameId];
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

            public Player GetPlayerDetails(string gameId, int playerId)
            {
                return _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
            }

            [HttpPut("{gameId}/players/{playerId}")]
            public Player UpdatePlayer(string gameId, int playerId, string name, PlayerColor color)
            {
                var player = _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
                player.Name = name;
                player.PlayerColor = color;
                return player;
            }


            [HttpDelete("{gameId}/players/{playerId}")]
            public bool DeletePlayer(string gameId, int playerId)
            {
                var player = _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
                return _games.GetGame(gameId).GetPlayers().Remove(player);
            }
        }
    }

    /* GET: api/PlayerId
    [HttpGet("{id}", Name = "Get")]
    public void GetPlayer(int id)
    {


    }

    // PUT: api/PlayerId
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Playerid
    [HttpDelete("{id}")]
    public void DeletePlayer(int id)
    {
    }*/

    // GET: api/Player
    [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Player
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
