namespace Application.Features.Authentication.Commands.Register;

public class RegistrationResponse
{
    public string UserId { get; set; } = null!;
    public string Bearer { get; set; } = null!;
    public string Role { get; set; } = null!;
}