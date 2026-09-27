
using System;
using System.ComponentModel.DataAnnotations;

namespace MadPay724.Data.Models
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifyDate { get; set; }
    }
}
