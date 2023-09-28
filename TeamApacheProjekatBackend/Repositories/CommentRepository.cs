using Microsoft.EntityFrameworkCore;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;

namespace TeamApacheProjekatBackend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Comment> _collection;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
            _collection = _context.Comments;
        }
        public void DeleteComment(Comment comment)
        {
            _collection.Remove(comment);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Comment>> FindAll(int postId)
        {
            return await _collection.AsNoTracking().Include(c => c.User).Include(c => c.Post).Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<Comment> FindById(int Id)
        {
            return await _collection.AsNoTracking().Include(c => c.User).Include(c => c.Post).FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<Comment> InsertComment(Comment Comment)
        {
            //Comment.CommentDateTime = DateTime.Now;
            _collection.Add(Comment);
            _context.SaveChanges();
            return Comment;
        }

        public void UpdateComment(Comment Comment)
        {
            //_collection.Entry(Comment).State = EntityState.Modified;
            _collection.Update(Comment);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

    }
}
