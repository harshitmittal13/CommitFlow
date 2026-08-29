namespace CommitFlow.DTOs.NewUser
{
    public class NewUserResponseDTO
    {
        /// <summary>
        /// Indicates whether the user creation was successful.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier of the newly created user. If the creation failed, this will be Guid.Empty.
        /// </summary>
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
