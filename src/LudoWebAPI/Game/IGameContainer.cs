using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;

namespace LudoWebAPI.Game
{
    public interface IGameContainer
    {
        LudoGame this[int gameId]
        {
            get;
        }

        List<int> GetAllGameIds();
        LudoGame CreateGame(int id);
        bool DeleteGame(int id);
    }
}
