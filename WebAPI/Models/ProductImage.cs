using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }

        // Foreign key table product
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
