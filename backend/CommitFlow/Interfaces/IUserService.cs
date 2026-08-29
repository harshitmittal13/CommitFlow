using CommitFlow.DTOs.NewUser;

namespace CommitFlow.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user in the system based on the provided request data.
        /// </summary>
        public Task<NewUserResponseDTO> CreateNewUser(NewUserRequestDTO req);
    }
}
