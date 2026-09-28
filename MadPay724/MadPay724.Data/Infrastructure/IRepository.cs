using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MadPay724.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity Get(object id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where);
    }
}
