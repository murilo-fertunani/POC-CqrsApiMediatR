using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsApiMediatr.Domain.Entities
{
    public class ProductEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string Name { get; set; }

        public string BarCode { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Fee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get; set; }

        public ProductEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            IsActive = true;
        }
    }
}