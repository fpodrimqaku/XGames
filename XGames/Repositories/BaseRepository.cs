using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;

namespace XGames.Repositories
{
    public class BaseRepository<T> where T:BaseModel
    {
       private readonly XGamesContext _context;

            public BaseRepository(XGamesContext context) {
            this._context = context;
        }






        public async Task<IActionResult> Index(String SearchString, string GameGenre)
        {
          
            IQueryable<string> genreQuery = from m in _context.Game
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Game
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(GameGenre))
            {
                movies = movies.Where(x => x.Genre == GameGenre);
            }

            var GameGenreVM = new GameGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Games = await movies.ToListAsync()
            };

            return View(GameGenreVM);
        }

        public JsonResult CurrentDate([FromServices] IDateTime _dateTime)
        {
            return Json(new { time = _dateTime });
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

    
        public async Task<T> Create( T entity)
        {
                var entityReturned = _context.Add<T>(entity);
                await _context.SaveChangesAsync();
                return entityReturned.Entity;
            }
          
        

        //// GET: Games/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var game = await _context.Game.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(game);
        //}

       
        public async Task<T> Update(int id,T entity) 
        {
            if (id != entity.ID)
            {
                throw new KeyNotFoundException();
            }

            if (entity != null)
            {
                try
                {
                    _context.Update<T>(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.ID))
                    {
                        throw new KeyNotFoundException();
                    }
                    else
                    {
                        throw;
                    }
                }
                return entity;
            }
            else {
                throw new NullReferenceException();
            }
        }

     
      
        public async Task<bool> DeleteConfirmed(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Find<T>(new { ID=id }) !=null;
        }











    }
}
