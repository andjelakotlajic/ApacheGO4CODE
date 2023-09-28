using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Dto
{
    public class PostCreateDto
    {

        public string? Text { get; set; }
        //public string? Attachment { get; set; }
        public List<PostLabelDto>? Labels { get; set; }
    }
}
