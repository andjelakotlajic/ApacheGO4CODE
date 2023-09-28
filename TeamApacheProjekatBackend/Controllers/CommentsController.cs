using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentsController(ICommentService commentService)
        {
            _service = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentGetDetailsResponseDTO>>> Get(int postId)
        {
            var result = await _service.GetAllAsync(postId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentGetDetailsResponseDTO>> GetDetails(int id)
        {
            var result = await _service.GetAsync(id);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CommentGetDetailsResponseDTO>> Post(CommentCreateRequestDTO comment)
        {
            var result = await _service.CreateAsync(comment);

            return CreatedAtAction(nameof(GetDetails), new { id = result.Id }, result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return result == false ? NotFound() : NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CommentCreateRequestDTO updateDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAsync(id);
            if (result == null)
            {
                return BadRequest(ModelState);
            }
            _service.Update(id, updateDTO);
            return Ok(result);
        }
    }
}
