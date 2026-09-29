using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4,ErrorMessage ="a")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "b")]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
