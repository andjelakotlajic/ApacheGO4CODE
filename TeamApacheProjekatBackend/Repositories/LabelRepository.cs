using Microsoft.EntityFrameworkCore;
using TeamApacheProjekatBackend.Models;
using TeamApacheProjekatBackend.Repositories.Interfaces;

namespace TeamApacheProjekatBackend.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly AppDbContext _context;
        public LabelRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteLabel(PostLabel postLabel)
        {
            _context.Remove(postLabel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostLabel>> GetLabelsByPostId(int postId)
        {
            var labels = await _context.PostLabels.Where(l => l.PostId == postId).ToArrayAsync();
            return labels;
        }

        public async Task<PostLabel> GetLabelsByPostIdAsync(int postId)
        {
            var label = await _context.PostLabels.FirstOrDefaultAsync(l => l.PostId == postId);
            return label;
        }

        public async Task UpdateLabel(PostLabel postLabel)
        {
            _context.PostLabels.Update(postLabel);
            await _context.SaveChangesAsync();
        }
    }
}
