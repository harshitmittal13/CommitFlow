using CommitFlow.DTOs;
using CommitFlow.DTOs.NewUser;
using CommitFlow.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommitFlow.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserService _userService;
        public UserController(IJwtTokenService jwtTokenService, IUserService userService)
        {
            _jwtTokenService = jwtTokenService;
            _userService = userService;
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Create/NewUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] NewUserRequestDTO req)
        {
            if (req.FirstName.Trim().Length == 0)
            {
                return BadRequest("First name is required.");
            }
            if (req.LastName.Trim().Length == 0)
            {
                return BadRequest("Last name is required.");
            }
            if (req.Email.Trim().Length == 0)
            {
                return BadRequest("Email is required.");
            }
            if (req.Password.Trim().Length == 0)
            {
                return BadRequest("Password is required.");
            }
            if (req.Password.Trim().Length < 6)
            {
                return BadRequest("Password must be at least 6 characters long.");
            }
            NewUserResponseDTO response = await _userService.CreateNewUser(req);
            return Ok(response);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if the credentials are valid.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("User")]
        [Authorize]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginRequestDTO req)
        {
            return Ok();
        }
    }
}
