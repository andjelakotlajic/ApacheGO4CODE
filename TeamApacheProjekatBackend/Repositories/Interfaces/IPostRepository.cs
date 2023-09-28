using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task CreatePost(Post post);
        public Task UpdatePost(Post post);
        public Task DeletePost(Post post);
        public Task<IEnumerable<Post>> GetAllPosts();
        public Task<IEnumerable<Post>> GetUsersPost(int userId);
        public Task<Post> GetPostById(int id);
        Task<List<Rating>> GetRatingsByUserId(int postId, int userId);
        Task AddRate(Rating rating);
        Task RemoveUserRate(int userId, int postId);
        Task<double?> GetRateAverage(int postId);
    }
}
