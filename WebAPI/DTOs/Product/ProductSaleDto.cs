namespace WebAPI.DTOs.Product
{
    public class ProductSaleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double PriceOld { get; set; }
        public double PriceNew { get; set; }
        public int? Discount { get; set; }
        public string DefaultImage { get; set; }
    }
}
