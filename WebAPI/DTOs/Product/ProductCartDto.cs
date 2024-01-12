namespace WebAPI.DTOs.Product
{
    public class ProductCartDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DefaultImage { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
