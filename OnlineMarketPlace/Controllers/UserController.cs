using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Data.DTO;
using OnlineMarketPlace.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// User controller constructor.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="logger"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a user
        /// </summary>
        /// <returns>User model</returns>
        [HttpPost("/register")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody]Auth auth)
        {
            var response = await _userService.Register(auth.Email, auth.Password);
            return Ok(response);
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <returns>User model</returns>
        [HttpPost("/login")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] Auth auth)
        {
            // Implement here
            throw new NotImplementedException();
        }
    }
}