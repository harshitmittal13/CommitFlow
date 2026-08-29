using System.ComponentModel.DataAnnotations;

namespace CommitFlow.DTOs.NewUser
{
    public class NewUserRequestDTO
    {
        //User First name
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        //User Last name
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        //User Email
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        // Hashed password. Never store plaintext passwords.
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
