namespace Application.Features.Authentication.Commands.Login;

public class LoginResponse
{
    public string UserId { get; set; } = null!;
    public string Bearer { get; set; } = null!;
    public string Role { get; set; } = null!;
}