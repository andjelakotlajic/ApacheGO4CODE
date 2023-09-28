using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User getUserByUsername(string username);
    }
}
