using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Dto
{
    public class Post_reviewsDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? AttachmentId { get; set; }
        public int? Views { get; set; }
        public int? Rating { get; set; }
        public List<PostLabel>? PostLabels { get; set; } = new List<PostLabel>();

        public List<CommentGetDetailsResponseDTO>? Comments { get; set; } 
    }
}
