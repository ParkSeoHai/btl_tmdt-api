using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs.ShopAddress
{
    public class ShopAddressDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlMap { get; set; }
    }
}
