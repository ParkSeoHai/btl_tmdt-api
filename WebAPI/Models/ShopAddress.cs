using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class ShopAddress
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string UrlMap { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
