using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class RatingImage
    {
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }

        // Foreign key to table rating
        public Guid RatingId { get; set; }
        public Rating Rating { get; set; }
    }
}
