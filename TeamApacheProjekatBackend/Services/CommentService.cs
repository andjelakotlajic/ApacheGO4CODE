using Microsoft.AspNetCore.Http.HttpResults;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Services
{
    public class CommentService : ICommentService
    {
        public readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        //public readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository,IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
           _userRepository = userRepository;
        }

        public async Task<CommentGetDetailsResponseDTO> GetAsync(int id)
        {
            var comment  = await _commentRepository.FindById( id );
            var  returnDTO = new CommentGetDetailsResponseDTO()
            {
                Id = comment.Id,
                PostId = comment.PostId,
                UserId = comment.UserId,
                Text = comment.Text
            };
            return returnDTO;
        }

        public async Task<IEnumerable<CommentGetDetailsResponseDTO>> GetAllAsync(int postId)
        {
            var comments = await _commentRepository.FindAll(postId);
            //return _mapper.Map<IEnumerable<CommentGetDetailsResponseDTO>>(comments);
            List<CommentGetDetailsResponseDTO> commentsList = new List<CommentGetDetailsResponseDTO>();
            foreach (var comment in comments)
            {
                var dto = new CommentGetDetailsResponseDTO()
                {
                    Id = comment.Id, PostId = comment.PostId, Text = comment.Text, UserId = comment.UserId
                };
                commentsList.Add(dto);
            }
            return commentsList;
        }

        public async Task<CommentGetDetailsResponseDTO> CreateAsync(CommentCreateRequestDTO commentDTO,string username)
        {
            var user = _userRepository.getUserByUsername(username);
            var commentEntity = new Comment { PostId = commentDTO.PostId, Text=commentDTO.Text, UserId = user.Id };
            var result = await _commentRepository.InsertComment(commentEntity);
            var returnDTO = new CommentGetDetailsResponseDTO { Id = result.Id, UserId = result.UserId, PostId = result.PostId, Text = result.Text };
            //return _mapper.Map<CommentGetDetailsResponseDTO>(result);
            return returnDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _commentRepository.FindById(id);
            if (exists == null)
            {
                return false;
            }

            _commentRepository.DeleteComment(exists);

            return true;
        }

        public void Update(int id, CommentCreateRequestDTO commentDTO,string username)
        {
            var user = _userRepository.getUserByUsername(username);
            var commentEntity = new Comment { Id = id,  PostId = commentDTO.PostId, Text = commentDTO.Text, UserId = user.Id};
            _commentRepository.UpdateComment(commentEntity);
        }
    }
}
