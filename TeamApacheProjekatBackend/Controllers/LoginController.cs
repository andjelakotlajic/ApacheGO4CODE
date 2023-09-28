using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterDto registerDto)
        {
            try
            {
                _loginService.Register(registerDto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _loginService.Login(loginDto);
            if (token != null)
            {
                if (token == string.Empty)
                {
                    return BadRequest("Wrong password!");

                }
                return Ok(token);
            }
            else
            {
                return BadRequest("Wrong username!");
            }
        }
    }
}
