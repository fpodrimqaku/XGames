using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Data;
using XGames.Models;
using XGames.Repositories;
using XGames.Repositories.RepositoryInterfaces;

namespace XGames.BusinessLogic
{
    public class GamePictureBLL:BaseBLL<GamePicture>,IGamePictureBLL
    {
        public GamePictureBLL([FromServices]IGamePictureRepository GamePictureRepo) : base(GamePictureRepo) { }

    }
}
