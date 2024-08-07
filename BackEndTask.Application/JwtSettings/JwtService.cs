using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO.Pipes;
using System.Security.Claims;
using System.Text;
using BackEndTask.Application.UserService.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackEndTask.Application.JwtSettings
{
    public class JwtService : IJwtService
    {
        private readonly string _jwtSettings;

        public JwtService(IConfiguration configuration)
        {
            _jwtSettings = configuration.GetSection("Jwt:Key").Value;
        }

        public string GenerateToken(UserAuthDTO user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentNullException(nameof(user), "User or UserName cannot be null.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(50),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
