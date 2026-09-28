using System;
using System.ComponentModel.DataAnnotations;

namespace MadPay724.Data.Models
{
    public class BankCard : BaseEntity<string>
    {
        public BankCard()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }

        [Required]
        public string BankName { get; set; }

        [Range(16, 16)]
        public string IBAN { get; set; }

        [Required]
        public int CardNumber { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpireDateMonth { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpireDateDay { get; set; }

        public User User { get; set; }
    }
}
