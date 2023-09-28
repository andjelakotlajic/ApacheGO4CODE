namespace TeamApacheProjekatBackend.Dto
{
    public class CommentGetDetailsResponseDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        //public DateTime CommentDateTime { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
