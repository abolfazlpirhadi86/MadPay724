using MadPay724.Common.Helpers;
using MadPay724.Data.DataBaseContext;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Repository.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MadPay724.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = _dbContext ?? (ApplicationDBContext)_dbContext;
        }

        
    }
}
