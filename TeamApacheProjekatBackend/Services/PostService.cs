using System.Collections.Generic;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories;
using TeamApacheProjekatBackend.Repositories.Interfaces;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly ICommentRepository _commentRepository;
      

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ILabelRepository labelRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _labelRepository = labelRepository;
            _commentRepository = commentRepository; 
        }

        public async Task AddRate(AddRatingDto dto, string username, int postId)
        {
            
            var user = _userRepository.getUserByUsername(username);
            try
            {
                var post = await _postRepository.GetPostById(postId);
                var existingRates = await _postRepository.GetRatingsByUserId(postId, user.Id);
                if (existingRates == null)
                {
                    var rate = new Rating
                    {
                        PostId = post.Id,
                        UserId = user.Id,
                        Rate = dto.Rate,

                    };
                    await _postRepository.AddRate(rate);
                }

                else
                {
                    var rate = new Rating
                    {
                        PostId = post.Id,
                        UserId = user.Id,
                        Rate = dto.Rate,

                    };
                    await _postRepository.RemoveUserRate(post.Id, user.Id);
                    await _postRepository.AddRate(rate);
                }

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
           
           
        }

        public async Task CreatePost(PostCreateDto post, string username)
        {
            var user = _userRepository.getUserByUsername(username);

            var newPost = new Post
            {
                User = user,
                Text = post.Text,
                CreatedTime = DateTime.Now
                //attachment 
            };

            foreach (var labelDto in post.Labels)
            {
                newPost.PostLabels.Add(new PostLabel
                {
                    Content = labelDto.Content
                });

            }
            await _postRepository.CreatePost(newPost);
        }

        public async Task DeletePost(int id)
        {

            var post = await _postRepository.GetPostById(id);
            if (post == null)
            {
                throw new Exception($"Unable to delete post {id}");
            }
            else
            {
                var labels = await _labelRepository.GetLabelsByPostId(post.Id);
                foreach (var labelDto in labels)
                {
                    await _labelRepository.DeleteLabel(labelDto);
                }

               await _postRepository.DeletePost(post);
                //treba da se doda brisanje komentara,attachment
            }
        }

        public async Task<IEnumerable<Post_reviewsDto>> GetAllPosts()
        {

            var posts =  await _postRepository.GetAllPosts();
            var postDtos = new List<Post_reviewsDto>();

            foreach (var post in posts)
            {
                var postDto = new Post_reviewsDto
                {
                    Id = post.Id,
                    UserId = post.UserId,
                    Text = post.Text,
                    CreatedTime = DateTime.Now,
                    Views = post.Views,
                    Rating = post.Rating,
                    User = post.User
                };
                foreach(var label in post.PostLabels)
                {
                    postDto.PostLabels.Add(label);
                }

                var comments = await _commentRepository.FindAll(post.Id);

                if (comments != null)
                {
                    var commDtos = new List<CommentGetDetailsResponseDTO>();
                    var username = await _userRepository.GetUsernameById(post.User.Id);
                    foreach (var comment in comments)
                    {

                        var dto = new CommentGetDetailsResponseDTO
                        {
                            Id = comment.Id,
                            UserId = comment.UserId,
                            Text = comment.Text,
                            PostId = post.Id,
                            username = username
                        };
                        commDtos.Add(dto);
                    }

                        postDto.Comments = commDtos;

                    
                }
                
                postDtos.Add(postDto);
            }
            return postDtos;
            
        }

        public async Task<double?> GetRateAverage(int postId)
        {
           return  await _postRepository.GetRateAverage(postId);
        }

        public Task<IEnumerable<Post>> GetUsersPost(string username)
        {
            var user = _userRepository.getUserByUsername(username);
            if (user != null)
            {
                return _postRepository.GetUsersPost(user.Id);
            }
            return null;
        }

        public async Task UpdatePost(PutPost post,int postId)
        {
            var postUpdate = await _postRepository.GetPostById(postId);
            postUpdate.Text= post.Text;
            await _postRepository.UpdatePost(postUpdate);
           
        }
        public async Task IncreasePostViews()
        {
            var posts = await _postRepository.GetAllPosts();

            foreach(var post in posts)
            {
                if (post.Views == null)
                {
                    post.Views = 1;
                }
                else
                {
                    post.Views = post.Views + 1;
                }
                
                await _postRepository.UpdatePost(post);

            }
        }
    }
}
