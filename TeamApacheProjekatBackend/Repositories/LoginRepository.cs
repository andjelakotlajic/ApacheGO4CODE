using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;

namespace TeamApacheProjekatBackend.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
