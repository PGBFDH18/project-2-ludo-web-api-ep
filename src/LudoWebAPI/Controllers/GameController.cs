﻿using System;
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

            if (_games.GetAllGameIds().Count < 1)
            {
                gameID = 1;
            }

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


        [HttpGet("{gameId}/players/{playerId}")]
        public Player GetPlayerDetails(int gameId, int playerId)
        {
            return _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
        }

        [HttpPut("{gameId}/players/{playerId}")]
        public Player UpdatePlayer(int gameId, int playerId, string name, PlayerColor color)
        {

            Player player = _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
            player.Name = name;
            player.PlayerColor = color;
            return player;
        }

        //Får inte denna att funka.
        /*[HttpDelete("{gameId}/players/{playerId}")]
        public bool DeletePlayer(int gameId, int playerId)
            {
            string sGameId = gameId.ToString();
            var player = _games.GetGame(gameId).GetPlayers().FirstOrDefault(x => x.PlayerId == playerId);
            return _games.GetGame(gameId).GetPlayers().Remove(player);*/



        // GET: api/Player
        [HttpGet("{gameId}/players")]
        public IEnumerable<Player> Get1(int gameId)
        {
            throw new NotImplementedException();
            //return ludoGames[gameId].GetPlayers().Select(p =>
            //    new LudoPlayer()
            //    {
            //        Color = p.PlayerColor.ToString(),
            //        Id = p.PlayerId,
            //        Name = p.Name
            //    }
            //    );
        }

        // POST: ludo/Player
        [HttpPost("{gameId}/players")]
        public ActionResult Post(int gameId, [FromBody] PlayerModel player)
        {
            PlayerColor playerColor = ParseColor(player.Color);
            try
            {
                //ludoGames[gameId].AddPlayer(player.Name, playerColor);
                return Ok();
            }
            catch
            {
                return BadRequest("Unable to add player");
            }
        }
        public PlayerColor ParseColor(string color)
        {
            switch (color.Trim().ToLower())
            {
                case "red": return PlayerColor.Red;
                case "green": return PlayerColor.Green;
                case "blue": return PlayerColor.Blue;
                case "yellow": return PlayerColor.Yellow;
            }
            throw new Exception($"Color {color} is unknown, the suported colors are: red, green, blue and yellow");
        }
    }
}