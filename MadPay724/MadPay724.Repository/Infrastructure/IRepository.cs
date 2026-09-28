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

        TEntity Get(object id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where);
    }
}
