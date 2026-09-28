using MadPay724.Common.Helpers;
using MadPay724.Data.DataBaseContext;
using MadPay724.Data.Models;
using MadPay724.Repository.Infrastructure;
using MadPay724.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadPay724.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<ApplicationDBContext> _dbContext;
        public UserService(IUnitOfWork<ApplicationDBContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Register(User user, string password)
        {
            var hashPass = Utilities.PasswordHash(password);
            user.PasswordSalt = hashPass.Item1;
            user.PasswordHash = hashPass.Item2;

            await _dbContext.UserRepository.Add(user);
            await _dbContext.SaveAsync();
            return user;
        }
        public async Task<IEnumerable<User>> GetAll() 
        {
            return await _dbContext.UserRepository.GetAll();
        }
    }
}
