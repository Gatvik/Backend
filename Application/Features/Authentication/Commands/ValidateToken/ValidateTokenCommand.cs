using Application.Models.Identity;
using MediatR;

namespace Application.Features.Authentication.Commands.ValidateToken;

public class ValidateTokenCommand : IRequest<ValidateTokenResponse>
{
    public string Token { get; set; } = null!;
}