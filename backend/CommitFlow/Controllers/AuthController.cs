using CommitFlow.DTOs.UserLogin;
using CommitFlow.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommitFlow.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if the credentials are valid.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("User")]
        [Authorize]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserLoginRequestDTO req)
        {
            return Ok();
        }
    }
}
