using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Core.Models
{
    public class CustomerItem : BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Required]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Item")]
        [Required]
        [DisplayName("Item number")]
        public int ItemId { get; set; }

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
        public Item Item { get; set; }

        public CustomerItem Clone()
        {
            return (CustomerItem)this.MemberwiseClone();
        }
    }
}
