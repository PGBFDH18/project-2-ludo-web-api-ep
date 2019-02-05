using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebAPI.Models
{
    public class MovePieceModel
    {
        public int PlayerId { get; set; }
        public int PieceId { get; set; }
        public int NumberOfFields { get; set; }
    }
}
