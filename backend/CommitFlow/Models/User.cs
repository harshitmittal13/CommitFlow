using System.ComponentModel.DataAnnotations;

namespace CommitFlow.Models
{
    public class User
    {
        //Globally unique User ID 
        [Required]
        public Guid UserId { get; set; }

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

        //User account created date
        public DateTime CreatedAtUtc { get; set; }

        //User Last updated
        public DateTime UpdatedAtUtc { get; set; }

        // User active status
        public bool IsActive { get; set; }
    }
}
