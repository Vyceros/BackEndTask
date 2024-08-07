using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Domain.Entities;

namespace BackEndTask.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task<Post> AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
    }
}