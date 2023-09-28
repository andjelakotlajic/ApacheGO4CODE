using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Repositories.Interfaces
{
    public interface ILabelRepository
    {
        public Task<IEnumerable<PostLabel>> GetLabelsByPostId(int  postId);

        public Task<PostLabel> GetLabelsByPostIdAsync(int postId);
        public Task DeleteLabel (PostLabel postLabel);

        public Task UpdateLabel (PostLabel postLabel);
    }
}
