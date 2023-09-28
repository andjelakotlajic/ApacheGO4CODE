using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentGetDetailsResponseDTO> CreateAsync(CommentCreateRequestDTO comment,string username);
        Task<IEnumerable<CommentGetDetailsResponseDTO>> GetAllAsync(int postId);
        Task<CommentGetDetailsResponseDTO> GetAsync(int id);
        public Task<bool> DeleteAsync(int id );
        void Update(int id, CommentCreateRequestDTO commentDTO,string username);
    }
}
