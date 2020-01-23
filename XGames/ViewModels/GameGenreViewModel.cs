using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.Models
{
    public class GameGenreViewModel
    {
            public List<Game> Games { get; set; }
            public SelectList Genres { get; set; }
            public string GameGenre { get; set; }
            public string SearchString { get; set; }
    }
}
