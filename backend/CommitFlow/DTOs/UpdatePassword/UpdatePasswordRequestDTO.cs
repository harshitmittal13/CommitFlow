using System.ComponentModel.DataAnnotations;

namespace CommitFlow.DTOs.UpdatePassword
{
    public class UpdatePasswordRequestDTO
    {
        /// <summary>
        /// The email address of the user whose password is to be updated.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The current password of the user, used for authentication before updating to a new password.
        /// </summary>
        [Required(ErrorMessage = "Current password is required.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// The new password that the user wants to set. This should meet any password complexity requirements defined by the system.
        /// </summary>
        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; } = string.Empty;
    }
}
