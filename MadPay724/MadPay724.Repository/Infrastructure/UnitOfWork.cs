using MadPay724.Repository.Repositories;
using MadPay724.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private bool disposed = false;
        protected readonly DbContext _dbContext;
        public UnitOfWork()
        {
            _dbContext = new TContext();
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                userRepository ??= new UserRepository(_dbContext);

                return userRepository;
            }
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

        #region Method
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
        #endregion

    }
}
