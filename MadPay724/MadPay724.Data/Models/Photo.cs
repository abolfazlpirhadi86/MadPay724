using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.Models
{
    internal class Photo : BaseEntity<int>
    {
        public Photo()
        {
            Id = new int();
            CreatedDate = DateTime.Now;
        }

        public string  UserId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Alt { get; set; }
        public bool IsMain { get; set; }

        public User User { get; set; }

    }
}
