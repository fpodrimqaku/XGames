using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XGames.Data;
using Microsoft.EntityFrameworkCore;
using XGames.Hubs;
using XGames.Services.Time;
using XGames.Repositories.RepositoryInterfaces;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Repositories.RepositoryInterfaces;
using XGames.Repositories;
using XGames.BusinessLogic;

namespace XGames
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTime, SystemDateTime>();
            services.AddControllersWithViews();
            services.AddDbContext<XGamesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("localDbString")));
            services.AddSignalR();



             services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICartRepository), typeof(CartRepository));
            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
             services.AddScoped(typeof(IGamePictureRepository), typeof(GamePictureRepository));
             services.AddScoped(typeof(ILineItemRepository), typeof(LineItemRepository));


             services.AddScoped(typeof(IBaseBLL<>), typeof(BaseBLL<>));
            services.AddScoped(typeof(ICartBLL), typeof(CartBLL));
            services.AddScoped(typeof(IGameBLL), typeof(GameBLL));
             services.AddScoped(typeof(IGamePictureBLL), typeof(GamePictureBLL));
             services.AddScoped(typeof(ILineItemBLL), typeof(LineItemBLL));

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Games}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
