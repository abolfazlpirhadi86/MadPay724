using MadPay724.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MadPay724.Data.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private bool disposed = false;
        protected readonly DbContext _dbContext;
        public UnitOfWork()
        {
            _dbContext = new TContext();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();
            disposed = true;
        }
        ~UnitOfWork() 
        {
            Dispose(false);
        }
    }
}
