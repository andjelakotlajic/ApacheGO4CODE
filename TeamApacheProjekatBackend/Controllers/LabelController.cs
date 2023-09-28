using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }
        [HttpGet("byPostId")]

        public async Task<ActionResult<IEnumerable<PostLabel>>> GetLabelsByPostId(int postId)
        {
            var results = await _labelService.GetLabelsByPostId(postId);
            return Ok(results);
        }

        [HttpDelete("postId")]

        public async Task<ActionResult> DeleteLabel(int labelId)
        {
             await _labelService.DeleteLabel(labelId);
            return Ok();
        }
    }
}
