using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Infrastructure.Data
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; } = DateTime.Today;

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
