﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebAPI.Models
{
    public class Gamemdoel
    {
        public string State { get; set; }
        public int GameId { get; set; }
        public int NumberOfPlayers { get; set; }
        public int CurrentPlayerId { get; set; }
    }
}
