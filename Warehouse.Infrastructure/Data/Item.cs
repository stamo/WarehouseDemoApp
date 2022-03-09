using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Infrastructure.Data
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string Barcode { get; set; }

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

        [Required]
        public Guid CategoryId { get; set; }

        public IList<Rack> Racks { get; set; } = new List<Rack>();

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
