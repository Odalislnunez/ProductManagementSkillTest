using System.ComponentModel;

namespace ProductManagement.Core.Models
{
    public class BaseModel
    {
        [DisplayName("Created by")]
        public string CreatedBy { get; set; }

        [DisplayName("Creation date")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Updated by")]
        public string? UpdatedBy { get; set; }

        [DisplayName("Update date")]
        public DateTime? UpdatedAt { get; set; }

        [DisplayName("Deleted by")]
        public string? DeletedBy { get; set; }

        [DisplayName("Deletion date")]
        public DateTime? DeletedAt { get; set; }
    }
}
