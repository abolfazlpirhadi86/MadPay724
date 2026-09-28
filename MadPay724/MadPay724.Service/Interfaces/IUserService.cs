using MadPay724.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadPay724.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
