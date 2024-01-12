using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
