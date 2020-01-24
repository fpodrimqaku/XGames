using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.Models
{
    public class LineItem : BaseModel
    {
        
        public int quantity { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
        

    }
}
