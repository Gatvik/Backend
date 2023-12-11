namespace Application.Features.Authentication.Commands.ValidateToken;

public class ValidateTokenResponse
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
}