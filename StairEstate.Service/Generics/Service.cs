using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Repo.Generics;

namespace StairEstate.Service.Generics
{
    public class Service<TEntity> : IService<TEntity> where TEntity: class
    {
        public IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Service()
        {
        }

        public TEntity GetById(int? id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> FindWithWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public void Create(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void CreateMany(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
        }

        public void Edit(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int? id)
        {
            _repository.Remove(id);
        }

        public void Delete(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
        }
    }
}
