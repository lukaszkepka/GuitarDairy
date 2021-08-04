using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Application.Interfaces
{
    public interface ICRUDRepository<TEntity>
      where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> Get(long id);
        Task<List<TEntity>> All(bool @readonly = false);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        IQueryable<TEntity> AsQueryable();
    }
}
