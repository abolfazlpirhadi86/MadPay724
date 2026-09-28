using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task Delete(TEntity entity)
        {
             _dbSet.Remove(entity);
        }
        public async Task Delete(object id)
        {
            var entity = Get(id);
            if (entity is null)
            {
                throw new ArgumentException();
            }

            _dbSet.Remove(entity);
        }
        public async Task Delete(Expression<Func<TEntity, bool>> condition)
        {
            List<TEntity> entities = _dbSet.Where(condition).ToList();
            foreach (TEntity entity in entities) 
            {
                _dbSet.Remove(entity);
            }
        }

        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Where(condition).FirstOrDefault();
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Where(condition).AsEnumerable();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
