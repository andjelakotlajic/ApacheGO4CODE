using TeamApacheProjekatBackend.Dto;

namespace TeamApacheProjekatBackend.Services.Interfaces
{
    public interface ILoginService
    {
        void Register(RegisterDto dto);
        string Login(LoginDto loginDto);
    }
}
