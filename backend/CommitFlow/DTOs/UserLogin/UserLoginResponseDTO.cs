namespace CommitFlow.DTOs.UserLogin
{
    public class UserLoginResponseDTO
    {
        /// <summary>
        /// Indicates whether the login attempt was successful.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The authentication token generated upon successful login.
        /// </summary>
        public string AuthToken { get; set; } = string.Empty;
    }
}
