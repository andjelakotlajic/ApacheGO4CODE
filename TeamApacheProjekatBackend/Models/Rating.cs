namespace TeamApacheProjekatBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public int? Rate { get; set; }
    }
}
