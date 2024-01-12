using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DefaultImage { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign key table brand
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        // Foreign key table SubCategory
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public List<ProductImage> Images { get; set; }

        public List<CartProduct> CartProducts { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
