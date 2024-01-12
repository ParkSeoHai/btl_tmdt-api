using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        // Foreign key table Category
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
