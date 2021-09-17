using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMarketPlace.Data.DTO;
using OnlineMarketPlace.Data.Enums;
using OnlineMarketPlace.Exceptions;
using OnlineMarketPlace.Helpers;
using OnlineMarketPlace.Models;
using OnlineMarketPlace.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationDbContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public async Task<UserDto> Register(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new AppException("Invalid request, please provide register details");

            if (await UserExists(email))
                throw new AppException("Invalid email or already exists");

            User user = new User
            {
                UserId = Guid.NewGuid(),
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password, 10),
                UserRole = UserRole.Customer
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            User UserResponse = await FindByEmail(email);
            return GetUserDto(UserResponse);
        }

        public async Task<User> FindByEmail(String email)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                throw new UnauthorizedAccessException("Incorrect email or password");

            return user;
        }

        public async Task<UserDto> Login(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new AppException("Invalid request, please provide register details");

            User UserResponse = await FindByEmail(email);

            if (!BCrypt.Net.BCrypt.Verify(password, UserResponse.Password))
                throw new UnauthorizedAccessException("Incorrect email or password");

            return GetUserDto(UserResponse);
        }

        public async Task<User> GetById(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null)
                throw new UnauthorizedAccessException("Incorrect email or password");

            return user;
        }

        private UserDto GetUserDto(User userResponse)
        {
            UserDto user = new UserDto
            {
                UserId = userResponse.UserId,
                Email = userResponse.Email,
                FirstName = userResponse.FirstName,
                LastName = userResponse.LastName,
                UserRole = userResponse.UserRole.ToString(),
            };
            user.Token = GenerateJwtToken(user);

            return user;
        }

        private async Task<bool> UserExists(string email)
        {
            User exists = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return exists != null;
        }

        private string GenerateJwtToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            var token = new JwtSecurityToken(
                claims: tokenClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}