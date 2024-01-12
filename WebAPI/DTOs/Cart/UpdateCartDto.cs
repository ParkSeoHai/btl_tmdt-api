namespace WebAPI.DTOs.Cart
{
    public class UpdateCartDto
    {
        public string SessionId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
