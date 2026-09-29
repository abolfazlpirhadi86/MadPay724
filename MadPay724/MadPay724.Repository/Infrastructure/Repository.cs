using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
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
            var entity = await Get(id);
            if (entity is null)
            {
                throw new ArgumentException();
            }

            await Delete(entity);
        }
        public async Task Delete(Expression<Func<TEntity, bool>> condition)
        {
            List<TEntity> entities = _dbSet.Where(condition).ToList();
            foreach (TEntity entity in entities)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<TEntity> Get(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.Where(condition).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.Where(condition).ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> condition)
        {
            var result = await _dbContext.Set<TEntity>().AnyAsync(condition);
            return result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
