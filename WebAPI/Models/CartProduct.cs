using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [PrimaryKey(nameof(CartId), nameof(ProductId))]
    public class CartProduct
    {
        [Column(Order = 0)]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        [Column(Order = 1)]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
