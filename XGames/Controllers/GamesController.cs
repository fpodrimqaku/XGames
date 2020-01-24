using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XGames.BusinessLogic;
using XGames.Data;
using XGames.Models;
using XGames.Services.Time;

namespace XGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly XGamesContext _context;
        GameBLL gamesBLL;
        //private readonly IDateTime _dateTime;
        public GamesController(/*IDateTime datetime,*/ XGamesContext context )
        {
          //  _dateTime = datetime;
            _context = context;
            gamesBLL = new GameBLL(context);
        }


        // GET: Games
        public async Task<IActionResult> Index(String SearchString, string GameGenre,[FromServices] IDateTime _dateTime)
        {
            ViewData["Message"] = String.Format("hELLO USER TIME IS {0} ", _dateTime.Now.ToString("hh:mm:ss"));
            // Use LINQ to get list of genres.


            var movies = gamesBLL.GetAll();
            var Genres = new SelectList(movies.Select(item => item.Genre).Distinct().ToList());
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.ToLower().Contains(SearchString.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(GameGenre))
            {
                movies = movies.Where(x => x.Genre == GameGenre).ToList();
            }

            var GameGenreVM = new GameGenreViewModel
            {
                Genres = Genres,
                Games =  movies.ToList()
            };

            return View(GameGenreVM);
        }

        public JsonResult CurrentDate([FromServices] IDateTime _dateTime) {
            return Json(new { time = _dateTime });
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <0)
            {
                return NotFound();
            }

            var game = await gamesBLL.GetById(id );
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

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Picture,Rating")] Game game)
        {
            Game gameCreated=null;
            if (ModelState.IsValid)
            {
               gameCreated= await gamesBLL.Create(game);
                return RedirectToAction(nameof(Index));
            }
            return View(gameCreated);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <0)
            {
                return NotFound();
            }

            var game = await gamesBLL.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Picture")] Game game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }
            Game gameUpdated=null;
            if (ModelState.IsValid)
            {
                try
                {
                    gameUpdated= await gamesBLL.Update(id,game);
               
                }
                catch (Exception exe)
                {//-- not handled properly
                    throw exe;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gameUpdated ?? game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var game = await gamesBLL.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await gamesBLL.GetById(id);
            gamesBLL.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
