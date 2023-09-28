using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamApacheProjekatBackend.Dto;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;
using TeamApacheProjekatBackend.Services.Interfaces;

namespace TeamApacheProjekatBackend.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfigurationSection _secretKey;

        public LoginService(ILoginRepository loginRepository, IConfiguration config, IUserRepository userRepository)
        {
            _loginRepository = loginRepository;
            _secretKey = config.GetSection("SecretKey");
            _userRepository = userRepository;
        }

        public string Login(LoginDto loginDto)
        {
            var user = _userRepository.getUserByUsername(loginDto.UserName);
            if(user == null)
            {
                return ("User not found.");
            }
            if(!BCrypt.Net.BCrypt.Verify(loginDto.Password,user.Password))
            {
                return ("Invalid password.");
            }
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44398",
                claims: claims, //claimovi
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        }

        public void Register(RegisterDto dto)
        {
            try
            {
                var newUser = new User
                {
                    UserName = dto.UserName,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                };
                _loginRepository.Register(newUser);
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
