using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string PasswordHash { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public List<New> News { get; set; }

        public List<Role> Roles { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<Order> Orders { get; set; }
    }
}
