namespace WebAPI.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int StarPoint {  get; set; }
        public string? Comment { get; set; }
        public int? LikePoint { get; set; }
        public DateTime CreatedDate { get; set; }

        // Foreign key to table user
        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<RatingImage> Images { get; set; }
    }
}
