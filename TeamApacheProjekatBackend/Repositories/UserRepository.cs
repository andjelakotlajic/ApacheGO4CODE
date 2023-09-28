using Microsoft.EntityFrameworkCore;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;

namespace TeamApacheProjekatBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public User getUserByUsername(string username)
        {
            return _context.Users.Where(u => u.UserName == username).FirstOrDefault();
        }
        public async Task<string> GetUsernameById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user.UserName;
        }
    }
}
