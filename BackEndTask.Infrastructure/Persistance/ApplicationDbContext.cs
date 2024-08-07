
using BackEndTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Infrastructure.Persistance;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : DbContext(options)
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Post> Posts { get; set; }
    internal DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}