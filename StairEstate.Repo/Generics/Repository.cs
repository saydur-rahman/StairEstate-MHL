using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Data;

namespace StairEstate.Repo.Generics
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly MHLDB Context;

        public Repository(MHLDB imhldb)
        {
            Context = imhldb;
        }


        public TEntity Get(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }




        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remove(int? id)
        {
            var entity = Get(id);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }


        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }

        //public void Save()
        //{
        //    Context.SaveChanges();
        //}

        public void Dispose()
        {
            Context?.Dispose();
        }

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
