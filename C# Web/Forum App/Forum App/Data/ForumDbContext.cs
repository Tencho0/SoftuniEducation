namespace Forum_App.Data
{
    using Forum_App.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
