using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.Models;

namespace XGames.Repositories.RepositoryInterfaces
{
   public interface IBaseRepository<T> where T : BaseModel
    {

        XGamesContext _context { get; }

        protected XGamesContext getDatabaseContext();


        public DbSet<T> GetAllAsSet();


        public  Task<T> GetById(int id);


        public  Task<T> Create(T entity);


        public  Task<T> Update(int id, T entity);



        public  Task<bool> Delete(int id);

        public bool EntityExists(int id);

    }
}
