using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;

namespace XGames.BusinessLogic
{
    public class GameBLL : BaseBLL<Game> 
    {
        public GameBLL([FromServices]XGamesContext xGamesContext) :base(xGamesContext) { }
    }
}
