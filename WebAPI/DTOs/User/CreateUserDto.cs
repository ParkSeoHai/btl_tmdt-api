using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
    }
}
