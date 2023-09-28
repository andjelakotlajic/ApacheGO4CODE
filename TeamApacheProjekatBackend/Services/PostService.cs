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
      

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }


        public async Task CreatePost(PostCreateDto post, string username)
        {
            var user = _userRepository.getUserByUsername(username);

            var newPost = new Post
            {
                User = user,
                Text = post.Text,
                CreatedTime = DateTime.Now
                //Labels = post.Labels.Select(PostLabelDto => new PostLabel { Content = PostLabelDto.Content}).ToList(),
                //attachment 
            };




            foreach (var labelDto in post.Labels)
            {
                newPost.PostLabels.Add(new PostLabel
                {
                    Content = labelDto.Content
                });

                //    // Dodajte novi PostLabel objekat u listu Labels novog posta

                //    if(await _labelRepository.CreateLabel(postLabel))
                //    {
                //          newPost.Labels.Add(postLabel);
                //    };
                //}

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
                _postRepository.DeletePost(post);
                //treba da se doda brisanje komentara,labela,attachment
            }
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
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

        public Task UpdatePost(PostCreateDto post)
        {
            throw new NotImplementedException();
        }
    }
}
