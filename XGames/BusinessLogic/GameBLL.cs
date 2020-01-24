using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Data;
using XGames.Models;
using XGames.Repositories;

namespace XGames.BusinessLogic
{
    public class GameBLL : BaseBLL<Game> ,IGameBLL
    {
        public GameBLL([FromServices]GameRepository gameRepo) :base(gameRepo) { }
    }
}
