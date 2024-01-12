using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign key to table brand
        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
