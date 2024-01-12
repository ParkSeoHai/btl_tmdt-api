namespace WebAPI.DTOs.Cart
{
    public class CreateProductCartDto
    {
        public string SessionId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
