using CommitFlow.DTOs.NewUser;
using CommitFlow.DTOs.UpdatePassword;
using CommitFlow.DTOs.UserLogin;

namespace CommitFlow.Interfaces
{
    public interface IUserDAO
    {
        /// <summary>
        /// Creates a new user in the system based on the provided request data.
        /// </summary>
        public Task<NewUserResponseDTO> CreateNewUser(NewUserRequestDTO req);

        /// <summary>
        /// Authenticates a user based on the provided user ID and email, returning a response containing authentication details.
        /// </summary>
        public Task<UserLoginResponseDTO> AuthenticateUser(UserLoginRequestDTO req);

        /// <summary>
        /// Updates the password for an authenticated user.
        /// </summary>
        public Task<string> UpdatePassword(UpdatePasswordRequestDTO req);
    }
}
