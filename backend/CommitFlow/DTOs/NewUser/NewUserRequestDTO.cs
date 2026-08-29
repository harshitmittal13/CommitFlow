using System.ComponentModel.DataAnnotations;

namespace CommitFlow.DTOs.NewUser
{
    public class NewUserRequestDTO
    {
        //User First name
        [Required]
        public string FirstName { get; set; } = string.Empty;

        //User Last name
        [Required]
        public string LastName { get; set; } = string.Empty;

        //User Email
        [Required]
        public string Email { get; set; } = string.Empty;

        // Hashed password. Never store plaintext passwords.
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
