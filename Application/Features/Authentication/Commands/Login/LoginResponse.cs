namespace Application.Features.Authentication.Commands.Login;

public class LoginResponse
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}