using System;
using System.Security.Cryptography;
using System.Text;
using CommitFlow.DTOs.NewUser;
using CommitFlow.DTOs.UserLogin;
using CommitFlow.DTOs.UpdatePassword;
using CommitFlow.Models;
using CommitFlow.Interfaces;

namespace CommitFlow.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;
        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        /// <summary>
        /// Creates a new user in the system based on the provided request data.
        /// </summary>
        public async Task<NewUserResponseDTO> CreateNewUser(NewUserRequestDTO req)
        {
            NewUserResponseDTO response = await _userDAO.CreateNewUser(req);
            return response;
        }

        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        public async Task<UserLoginResponseDTO> AuthenticateUser(UserLoginRequestDTO req)
        {
            UserLoginResponseDTO response = await _userDAO.AuthenticateUser(req);
            return response;
        }

        /// <summary>
        /// Updates the password for an authenticated user.
        /// </summary>
        public async Task<string> UpdatePassword(UpdatePasswordRequestDTO req)
        {
            string response = await _userDAO.UpdatePassword(req);
            return response;
        }
    }
}
