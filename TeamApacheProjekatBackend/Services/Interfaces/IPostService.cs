﻿using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface IPostService
    {
        public Task CreatePost(PostCreateDto post, string username);
        public Task UpdatePost(PutPost post,int postId);
        public Task DeletePost(int id);
        public Task<IEnumerable<Post_reviewsDto>> GetAllPosts();
        public Task<IEnumerable<Post>> GetUsersPost(string username);
        Task AddRate(AddRatingDto dto, string username, int postId);
        Task<double?> GetRateAverage(int postId);
        public Task IncreasePostViews();
    }
}
