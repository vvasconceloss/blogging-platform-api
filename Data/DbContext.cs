using bloggin_plataform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bloggin_plataform_api.Data
{
    public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Post>().ToTable("posts");
        }
    }
}