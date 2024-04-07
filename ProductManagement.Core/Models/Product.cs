using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core.Models
{
    public class Product : BaseModel
    {
        [Key]
        [Required]
        [DisplayName("Item number")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Default Price")]
        public double Price { get; set; }

        [Required]
        [DisplayName("Item category")]
        public char Category { get; set; }

        [Required]
        [DisplayName("Status")]
        public bool Status { get; set; } = true;

        public ICollection<CustomerProduct> CustomerProducts { get; set; }
    }
}
