using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Application.UserService.DTOs;
using BackEndTask.Domain.Entities;

namespace BackEndTask.Application.UserServices
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllusersAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> RegisterUserAsync(UserAuthDTO userAuthDto);
    }
}