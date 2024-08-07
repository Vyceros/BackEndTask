using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Application.UserService.DTOs;
using BackEndTask.Domain.Entities;
using BackEndTask.Domain.Repositories;

namespace BackEndTask.Application.UserServices
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllusersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<bool> RegisterUserAsync(UserAuthDTO userAuthDto)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(userAuthDto.UserName);
            if (existingUser != null)
            {
                return false;
            }

            var newUser = new User
            {
                UserName = userAuthDto.UserName,
                PasswordHash = userAuthDto.Password
            };

            await _userRepository.AddUserAsync(newUser);
            return await _userRepository.SaveChangesAsync();
        }
    }
}