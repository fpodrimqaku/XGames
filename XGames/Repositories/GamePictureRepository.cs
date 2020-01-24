using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;

namespace XGames.Repositories
{
    public class GamePictureRepository : BaseRepository<GamePicture>
    {
        public GamePictureRepository([FromServices]XGamesContext context) : base(context)
        {

        }

    }
}
