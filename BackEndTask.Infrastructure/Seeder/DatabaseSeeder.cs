using System;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Domain.Entities;
using BackEndTask.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Infrastructure.Seeder
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!await _context.Users.AnyAsync())
            {
                var user1 = new User
                {
                    UserName = "luka",
                    PasswordHash = "luka1"
                };
                var user2 = new User
                {
                    UserName = "john",
                    PasswordHash = "luka2"
                };
                _context.Users.AddRange(user1, user2);
                await _context.SaveChangesAsync();

                var post1 = new Post
                {
                    Title = "Test Post 1",
                    PostBody = "Test post body 1",
                    UserId = user1.Id
                };
                var post2 = new Post
                {
                    Title = "Test Post 2",
                    PostBody = "Test post body 2",
                    UserId = user2.Id
                };
                _context.Posts.AddRange(post1, post2);
                await _context.SaveChangesAsync();

                var comment1 = new Comment
                {
                    CommentBody = "Test Comment 1",
                    PostId = post1.Id,
                    UserId = user2.Id,
                    CreatedAt = DateTime.Now
                };
                var comment2 = new Comment
                {
                    CommentBody = "Test Comment 2",
                    PostId = post2.Id,
                    UserId = user1.Id,
                    CreatedAt = DateTime.Now
                };
                _context.Comments.AddRange(comment1, comment2);
                await _context.SaveChangesAsync();
            }
        }
    }
}