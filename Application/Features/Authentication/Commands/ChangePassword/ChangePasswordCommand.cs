using MediatR;

namespace Application.Features.Authentication.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Unit>
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}