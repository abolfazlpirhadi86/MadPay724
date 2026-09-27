using System;

namespace MadPay724.Data.Models
{
    internal class User : BaseEntity<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
