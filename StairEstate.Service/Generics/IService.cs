using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Service.Generics
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindWithWhere(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        void CreateMany(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);


        void Delete(int? id);
        void Delete(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entities);
    }
}
