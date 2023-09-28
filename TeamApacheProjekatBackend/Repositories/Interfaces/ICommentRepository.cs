using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> InsertComment(Comment Comment);
        Task<IEnumerable<Comment>> FindAll(int postId);
        Task<Comment> FindById(int Id);
        void UpdateComment(Comment Comment);
        void DeleteComment(Comment comment);
    }
}
