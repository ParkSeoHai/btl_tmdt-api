using WebAPI.DTOs.Product;

namespace WebAPI.DTOs.Cart
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public string sessionId { get; set; }
        public List<ProductCartDto> productCartDtos { get; set; }
    }
}
