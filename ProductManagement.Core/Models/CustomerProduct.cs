﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Core.Models
{
    public class CustomerProduct : BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Required]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Product")]
        [Required]
        [DisplayName("Item number")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public double Quantity { get; set; }

        [Required]
        [DisplayName("Price")]
        public double Price { get; set; }

        [Required]
        [DisplayName("Status")]
        public bool Status { get; set; } = true;

        [DisplayName("Customer")]
        public Customer Customer { get; set; }

        [DisplayName("Item")]
        public Product Product { get; set; }

        public CustomerProduct Clone()
        {
            return (CustomerProduct)this.MemberwiseClone();
        }
    }
}
