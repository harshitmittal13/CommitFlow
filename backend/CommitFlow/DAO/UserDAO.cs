using CommitFlow.Data;
using CommitFlow.DTOs.NewUser;
using CommitFlow.DTOs.UserLogin;
using CommitFlow.Models;
using Microsoft.EntityFrameworkCore;
using CommitFlow.Interfaces;

namespace CommitFlow.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly CommitFlowDbContext _dbContext;
        private readonly IJwtTokenService _jwtTokenService;
        public UserDAO(CommitFlowDbContext dbContext, IJwtTokenService jwtTokenService)
        {
            _dbContext = dbContext;
            _jwtTokenService = jwtTokenService;
        }

        /// <summary>
        /// Creates a new user in the system based on the provided request data.
        /// </summary>
        public async Task<NewUserResponseDTO> CreateNewUser(NewUserRequestDTO req)
        {
                // Check if the email already exists
                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
                if (existingUser != null)
                {
                    return new NewUserResponseDTO
                    {
                        Message = "Email already exists.",
                        UserId = Guid.Empty
                    };
                }
                // Create a new user entity
                User newUser = new User
                {
                    Email = req.Email,
                    Password = req.Password, // Assume HashPassword is a method to hash passwords
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    CreatedAtUtc = DateTime.UtcNow, // use CreatedAtUtc to match User type
                    UpdatedAtUtc = DateTime.UtcNow,
                    IsActive = true
                };
                // Add the new user to the database
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
            return new NewUserResponseDTO
            {
                Message = "User created successfully.",
                UserId = newUser.UserId
            };
        }

        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        public async Task<UserLoginResponseDTO> AuthenticateUser(UserLoginRequestDTO req)
        {
            // Check if the email and password match an existing user
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == req.Email && u.Password == req.Password);
            if (existingUser == null)
            {
                return new UserLoginResponseDTO
                {
                    Message = "Invalid email or password.",
                    AuthToken = string.Empty
                };
            }
            // Generate an authentication token (this is a simplified example)
            string authToken = _jwtTokenService.GenerateToken(existingUser.UserId, existingUser.Email);
            return new UserLoginResponseDTO
            {
                Message = "Authentication successful.",
                AuthToken = authToken
            };
        }
    }
}