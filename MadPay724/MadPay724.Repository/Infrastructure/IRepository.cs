using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(object id);
        Task Delete(Expression<Func<TEntity, bool>> where);
        Task<bool> Any(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> Get(object id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> where);
    }
}
