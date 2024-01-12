namespace WebAPI.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PriceOld { get; set; }
        public double PriceNew { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public string DefaultImage { get; set; }
        public string Brand { get; set; }
        public string SubCategory { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }
}
