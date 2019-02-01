using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;

namespace LudoWebAPI.Game
{
    public interface IGameContainer
    {
        List<int> GetAllGameIds();
        LudoGame CreateGame(int id);
        void DeleteGame(int id);
    }
}
