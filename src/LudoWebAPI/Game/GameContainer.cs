using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;

namespace LudoWebAPI.Game
{
    public class GameContainer : IGameContainer
    {
        private Dictionary<int, LudoGame> listOfGames;
        private IDiece diece;

        public GameContainer(IDiece di)
        {
            listOfGames = new Dictionary<int, LudoGame>();

        }

        public LudoGame this[int gameId]
        {
            get
            {
                if (!listOfGames.ContainsKey(gameId))
                {
                    CreateGame(gameId);
                }
                return listOfGames[gameId];
            }
        }

        public LudoGame CreateGame(int gameId)
        { 
            if (!listOfGames.ContainsKey(gameId))
            {
                listOfGames.Add(gameId, new LudoGame(new Diece()));
            }
            return listOfGames[gameId];
        }

        public void DeleteGame(int gameId)
        {
            listOfGames.Remove(gameId);
        }

        public List<int> GetAllGameIds()
        {
            return listOfGames.Select(d => d.Key).ToList();
        }
    }
}
