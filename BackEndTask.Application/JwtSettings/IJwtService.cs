using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTask.Application.UserService.DTOs;

namespace BackEndTask.Application.JwtSettings
{
    public interface IJwtService
    {
        string GenerateToken(UserAuthDTO user);
    }
}