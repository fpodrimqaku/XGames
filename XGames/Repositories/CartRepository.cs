using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;
using XGames.Repositories.RepositoryInterfaces;

namespace XGames.Repositories
{
    public class CartRepository : BaseRepository<Cart>,ICartRepository
    {
        public CartRepository([FromServices]XGamesContext context) :base(context) {
          
        }



    }
}
