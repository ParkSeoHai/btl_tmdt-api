using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string SesstionId { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}
