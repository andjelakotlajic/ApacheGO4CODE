using TeamApacheProjekatBackend.Dto;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentGetDetailsResponseDTO> CreateAsync(CommentCreateRequestDTO comment);
        Task<IEnumerable<CommentGetDetailsResponseDTO>> GetAllAsync(int postId);
        Task<CommentGetDetailsResponseDTO> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        void Update(CommentCreateRequestDTO commentDTO);
    }
}
