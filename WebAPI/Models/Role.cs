using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
