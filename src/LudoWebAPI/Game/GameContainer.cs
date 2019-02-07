using System.Collections.Generic;
using System.Linq;
using LudoGameEngine;

namespace LudoWebAPI.Game
{
    public class GameContainer : IGameContainer
    {
        private Dictionary<int, LudoGame> games;

        public GameContainer()
        {
            games = new Dictionary<int, LudoGame>();
        }

        public LudoGame this[int gameId]
        {
            get
            {
                if (!games.ContainsKey(gameId))
                {
                    games.Add(gameId, new LudoGame(new Diece()));
                }
                return games[gameId];
            }
        }

        public LudoGame CreateGame(int gameId)
        { 
            if (!games.ContainsKey(gameId))
            {
                games.Add(gameId, new LudoGame(new Diece()));
            }
            return games[gameId];
        }

        public bool DeleteGame(int gameId)
        {
            return games.Remove(gameId);
        }

        public List<int> GetAllGameIds()
        {
            return games.Select(d => d.Key).ToList();
        }
    }
}
