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
    }
}
