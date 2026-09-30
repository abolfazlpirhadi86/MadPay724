using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DTOs
{
    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
