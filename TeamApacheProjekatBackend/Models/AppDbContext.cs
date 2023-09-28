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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
         .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
       .HasMany(p => p.Labels) 
       .WithOne() 
       .HasForeignKey(pl => pl.PostId);

            modelBuilder.Entity<Post>()
    .HasOne(p => p.User) 
    .WithMany() 
    .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Comment>()
.HasOne(p => p.User)
.WithMany() 
.HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Comment>()
.HasOne(p => p.Post) 
.WithMany() 
.HasForeignKey(p => p.PostId);


            modelBuilder.Entity<PostLabel>()
        .HasKey(pl => pl.Id);

        }
    }
}
