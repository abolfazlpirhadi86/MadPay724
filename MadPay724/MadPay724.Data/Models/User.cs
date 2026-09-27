using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MadPay724.Data.Models
{
    internal class User : BaseEntity<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }

        public List<Photo> Photos { get; set; }
        public List<Photo> MyProperty { get; set; }
    }
}
