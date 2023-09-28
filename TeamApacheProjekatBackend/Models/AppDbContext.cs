using Microsoft.EntityFrameworkCore;

namespace TeamApacheProjekatBackend.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<PostLabel> PostLabels { get; set; }
        public DbSet<Rating> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
        .HasMany(p => p.PostLabels)
        .WithOne()
        .HasForeignKey(pl => pl.PostId);
        }
    }
}
