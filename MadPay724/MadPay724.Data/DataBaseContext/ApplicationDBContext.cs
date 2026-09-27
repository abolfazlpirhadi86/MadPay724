using Microsoft.EntityFrameworkCore;

namespace MadPay724.Data.DataBaseContext
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog:MadPay724DB;Integrated Security=true");
        }
    }
}
