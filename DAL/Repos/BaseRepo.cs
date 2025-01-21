using DAL.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repos
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void SaveChanges();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context context = new Context();

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            context.Set<T>().AddOrUpdate(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual T Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
