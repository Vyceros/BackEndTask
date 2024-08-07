using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Domain.Entities;
using BackEndTask.Domain.Repositories;
using BackEndTask.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BackEndTask.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
            .Include(p => p.Posts)
            .ToListAsync();
        }
    }
}