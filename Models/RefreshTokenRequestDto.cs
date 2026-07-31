namespace JwtAuthDotNet9.Models
{
    public class TokenResponseRequestDto
    {
        public Guid UserId { get; set; }

        public required string RefreshToken { get; set; }
    }
}