
using BackEndTask.Domain.Entities;

namespace BackEndTask.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user);
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<User>> GetAllUsersAsync();
}
