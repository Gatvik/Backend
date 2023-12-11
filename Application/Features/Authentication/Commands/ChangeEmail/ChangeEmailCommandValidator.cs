using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Commands.ChangeEmail;

public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
{
    private readonly UserManager<IdentityUser> _userManager;

    public ChangeEmailCommandValidator(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        RuleFor(c => c.NewEmail)
            .EmailAddress().WithMessage("Invalid email address")
            .MustAsync(IsUnique).WithMessage("Email address already taken");
    }

    private async Task<bool> IsUnique(string email, CancellationToken cts)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user is null;
    }
}