
using OnlineMarketPlace.Data.DTO;
using OnlineMarketPlace.Models;
using System;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Register(string email, string password);

        Task<UserDto> Login(string email, string password);

        Task<User> GetById(Guid userId);
    }
}