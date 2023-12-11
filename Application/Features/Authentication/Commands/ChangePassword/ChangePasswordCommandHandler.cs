using System.Text;
using Application.Contracts.Identity;
using Application.Exceptions;
using Application.Features.Authentication.Commands.ChangeEmail;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserService _userService;

    public ChangePasswordCommandHandler(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var user = await _userManager.FindByIdAsync(userId);

        var result = await _userManager.ChangePasswordAsync(user!, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.Append($"{err.Description}");
            }
                
            throw new BadRequestException(str.ToString());
        }
        
        return Unit.Value;
    }
}