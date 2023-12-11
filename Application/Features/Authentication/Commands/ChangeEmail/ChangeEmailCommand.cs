using MediatR;

namespace Application.Features.Authentication.Commands.ChangeEmail;

public class ChangeEmailCommand : IRequest<Unit>
{
    public string NewEmail { get; set; }
}