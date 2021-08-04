using GuitarDairy.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Infrastructure.EF.Repositories
{
    public class GenericRepository<TEntity> : ICRUDRepository<TEntity>, IDisposable
            where TEntity : class
    {
        private readonly GuitarDairyContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(GuitarDairyContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected GuitarDairyContext Context => _dbContext;

        protected DbSet<TEntity> DbSet => _dbSet;

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual Task<TEntity> Get(long id)
        {
            return DbSet.FindAsync(id).AsTask();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual Task<List<TEntity>> All(bool @readonly = false)
        {
            return @readonly
                ? DbSet.AsNoTracking().ToListAsync()
                : DbSet.ToListAsync();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }
    }
}
