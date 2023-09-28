using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Dto
{
    public class CommentCreateRequestDTO
    {
  
        public int? PostId { get; set; }
        public string Text { get; set; }
    }
}
