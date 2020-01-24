using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Models;

namespace XGames.BusinessLogic.BusinessLogicInterfaces
{
   public  interface IBaseBLL<T> where T : BaseModel
    {

        public List<T> GetAll();


        public  Task<T> GetById(int id);


        public  Task<T> Create(T entity);

        public  Task<T> Update(int id, T entity);


        public  Task<bool> Delete(int id);
        

        public bool EntityExists(int id);


    }
}
