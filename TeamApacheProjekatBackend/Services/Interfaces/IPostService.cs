using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface IPostService
    {
        public Task CreatePost(PostCreateDto post, string username);
        public Task UpdatePost(PutPost post,int postId);
        public Task DeletePost(int id);
        public Task<IEnumerable<Post>> GetAllPosts();
        public Task<IEnumerable<Post>> GetUsersPost(string username);
    }
}
