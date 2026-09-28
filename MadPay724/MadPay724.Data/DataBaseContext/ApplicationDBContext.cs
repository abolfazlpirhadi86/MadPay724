using MadPay724.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MadPay724.Data.DataBaseContext
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MadPay724DB;Integrated Security=true");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<BankCard> BankCard { get; set; }
    }
}
