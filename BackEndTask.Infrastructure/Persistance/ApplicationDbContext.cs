
using BackEndTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Infrastructure.Persistance;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : DbContext(options)
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Posts> Posts { get; set; }
    internal DbSet<Comments> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .HasMany(u => u.Posts)
        .WithOne()
        .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<User>()
        .HasMany(c => c.Comments)
        .WithOne()
        .HasForeignKey(k => k.UserId);

        modelBuilder.Entity<Posts>()
        .HasMany(c => c.Comments)
        .WithOne()
        .HasForeignKey(k => k.PostId);
    }
}