using Application.Contracts.Identity;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Commands.ChangeEmail;

public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Unit>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserService _userService;

    public ChangeEmailCommandHandler(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException("User not found, but it's impossible");

        var validationResult = await new ChangeEmailCommandValidator(_userManager).ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid email address", validationResult);
        
        var changeUserNameResult = await _userManager.SetUserNameAsync(user, request.NewEmail);
        if (!changeUserNameResult.Succeeded)
            throw new ArgumentException("Change username operation went wrong, but it's impossible");
        
        var emailToken = await _userManager.GenerateChangeEmailTokenAsync(user!, request.NewEmail);
        var changeEmailResult = await _userManager.ChangeEmailAsync(user, request.NewEmail, emailToken);
        if (!changeEmailResult.Succeeded)
            throw new ArgumentException("Change email operation went wrong, but it's impossible");

        return Unit.Value;
    }
}