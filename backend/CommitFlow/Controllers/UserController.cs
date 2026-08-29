using CommitFlow.DTOs.NewUser;
using CommitFlow.DTOs.UpdatePassword;
using CommitFlow.DTOs.UserLogin;
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
        [HttpPost("Auth")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserLoginRequestDTO req)
        {
            UserLoginResponseDTO response = await _userService.AuthenticateUser(req);
            return Ok(response);
        }

        /// <summary>
        /// Updates the password for an authenticated user.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Update/Password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequestDTO req)
        {
            if (req.NewPassword.Trim().Length < 6)
            {
                return BadRequest("New password must be at least 6 characters long.");
            }
            if (req.NewPassword == req.Password)
            {
                return BadRequest("New password cannot be the same as the current password.");
            }
            String response = await _userService.UpdatePassword(req);
            return Ok(response);
        }
    }
}
