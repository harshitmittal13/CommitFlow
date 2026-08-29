using System.ComponentModel.DataAnnotations;

namespace CommitFlow.DTOs.UserLogin
{
    public class UserLoginRequestDTO
    {
        /// <summary>
        /// The email address of the user attempting to log in.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        public String Email { get; set; } = string.Empty;
        /// <summary>
        /// The password of the user attempting to log in.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        public String Password { get; set; }
    }
}
