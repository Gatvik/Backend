using FluentValidation;

namespace Application.Features.Authentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(l => l.Email)
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}