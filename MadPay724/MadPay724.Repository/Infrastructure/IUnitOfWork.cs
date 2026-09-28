using MadPay724.Repository.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace MadPay724.Repository.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : Microsoft.EntityFrameworkCore.DbContext,new ()
    {
        IUserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
