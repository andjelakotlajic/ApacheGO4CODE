using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("GetRateAverage")]
        [Authorize]
        public async Task<ActionResult<double>> GetRateAverage(int postId)
        {
            try
            {
                return Ok(await _postService.GetRateAverage(postId));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddRate")]
        [Authorize]
        public async Task<ActionResult> AddRate([FromBody] AddRatingDto dto, int postId)
        {
            try
            {
                var username = User.Identity.Name;
                await _postService.AddRate(dto, username, postId);
                return Ok("Rate added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("allPosts")]

        public async Task<ActionResult<IEnumerable<PostCreateDto>>> AllPost()
        {
            var result = await _postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet("user posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetUsersPost()
        {
            var username = User.Identity.Name;
            var post = await _postService.GetUsersPost(username);
            if (post == null)
            {
                return BadRequest("Not found user");
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDto post)
        {
            try
            {
                var username = User.Identity.Name;
                await _postService.CreatePost(post, username);
                return Ok("Post added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]

        public async Task<ActionResult> UpdatePost([FromBody] PutPost post, int postId)
        {
            await _postService.UpdatePost(post, postId);
            return Ok();
        }
    }
}
