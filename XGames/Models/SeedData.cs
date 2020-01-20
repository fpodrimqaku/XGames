using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XGames.Data;

namespace XGames.Models
{

    public class SeedData
    {
        //private readonly XGamesContext context;
        public static void Initialize(IServiceProvider ServiceProvider) {


            using (var context = new XGamesContext(
                ServiceProvider.GetRequiredService<
                    DbContextOptions<XGamesContext>>())) {

                // Look for any movies.
                if (context.Game.AnyAsync<Game>().Result)
                {
                    return;   // DB has been seeded
                }

                context.AddRange(
                    new Game() {Genre="Action",Price=10.34M,Picture="No Pic Available",Title="Eragon",ReleaseDate=DateTime.Now.AddYears(-5) },
                    new Game() { Genre = "Shooter", Price = 4.34m, Picture = "No Pic Available", Title = "Fortnite", ReleaseDate = DateTime.Now.AddYears(-5) },
                    new Game() { Genre = "Third Person", Price = 4.90M, Picture = "No Pic Available", Title = "GTA 5", ReleaseDate = DateTime.Now.AddYears(-5) },
                    new Game() { Genre = "Action", Price = 6.34M, Picture = "No Pic Available", Title = "Eragon", ReleaseDate = DateTime.Now.AddYears(-5) }

                    );
                context.SaveChanges();

}    
        }
    }
}
