﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core.Models
{
    public class Customer : BaseModel
    {
        [Key]
        [Required]
        [DisplayName("Customer")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be 10 digits.")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Status")]
        public bool Status { get; set; } = true;

        public ICollection<CustomerProduct> CustomerProducts { get; set; }
    }
}
