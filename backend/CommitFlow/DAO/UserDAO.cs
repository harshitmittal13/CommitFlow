using CommitFlow.Data;
using CommitFlow.DTOs.NewUser;
using CommitFlow.Models;
using Microsoft.EntityFrameworkCore;
using CommitFlow.Interfaces;

namespace CommitFlow.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly CommitFlowDbContext _dbContext;
        public UserDAO(CommitFlowDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
