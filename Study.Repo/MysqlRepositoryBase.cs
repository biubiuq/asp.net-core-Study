using Microsoft.EntityFrameworkCore;
using Study.Extension;
using Study.IRepo;
using System;

namespace Study.Repo
{
    public class MysqlRepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        
        public DbContext db=new mysqlContext(null);
        bool IRepositoryBase<T>.Delete(T t)
        {
            db.Set<T>().Attach(t);
            db.Set<T>().Remove(t);
            return db.SaveChanges()==1;

        }

        T IRepositoryBase<T>.GetT(string Id)
        {
            return db.Find(typeof(string),Id) as T;
        }

        bool IRepositoryBase<T>.UpData(T t)
        {
            var dbEntityEntry = db.Entry(t);
           return db.SaveChanges()==1;
          
        }
    }
}
