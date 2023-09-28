using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface ILabelService
    {
        public Task<IEnumerable<PostLabel>> GetLabelsByPostId(int postId);
        public Task DeleteLabel(int labelId);
    }
}
