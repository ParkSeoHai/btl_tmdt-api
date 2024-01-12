using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class New
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign key to table user
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
