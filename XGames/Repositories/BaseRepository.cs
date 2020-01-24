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


        public XGamesContext getDatabaseContext() { return _context; }


        public DbSet<T> GetAllAsSet() {

            return _context.Set<T>();
        }

        
        public async Task<T> GetById(int id)
        {

            var entity = await _context.FindAsync<T>(new { ID = id });

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            return entity;
        }


    
        public async Task<T> Create( T entity)
        {
                var entityReturned = _context.Add<T>(entity);
                await _context.SaveChangesAsync();
                return entityReturned.Entity;
            }
          
        
       
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

     
      
        public async Task<bool> Delete(int id)
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
