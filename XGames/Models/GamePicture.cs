using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.Models
{
    public class GamePicture :BaseModel
    {
     
        public string URI { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
