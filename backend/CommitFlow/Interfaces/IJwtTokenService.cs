namespace CommitFlow.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid userId, string email);
    }
}
