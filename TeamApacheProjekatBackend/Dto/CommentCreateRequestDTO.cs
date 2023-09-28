namespace TeamApacheProjekatBackend.Dto
{
    public class CommentCreateRequestDTO
    {
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string Text { get; set; }
    }
}
