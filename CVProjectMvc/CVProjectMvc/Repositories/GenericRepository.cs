using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CVProjectMvc.Models.Entity;

namespace CVProjectMvc.Repositories
{
    public class GenericRepository <T> where T:class, new()
    {
        DbCVProjeEntities2 db = new DbCVProjeEntities2 ();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }

        public void Delete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }

        public void Update(T t)
        {
            db.SaveChanges(); 
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }
    }
}