using System.Text;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMemberRepository _memberRepository;

    public RegisterCommandHandler(UserManager<IdentityUser> userManager, IMemberRepository memberRepository)
    {
        _userManager = userManager;
        _memberRepository = memberRepository;
    }
    
    public async Task<RegistrationResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegistrationCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid registration data.", validationResult);
        
        var user = new IdentityUser
        {
            Email = request.Email,
            UserName = request.Email,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.Append($"{err.Description}");
            }
                
            throw new BadRequestException(str.ToString());
        }
        
        var member = new Domain.Member()
        {
            IdentityId = user.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Sex = request.Sex
        };
        
        await _userManager.AddToRoleAsync(user, "Member");
        await _memberRepository.CreateAsync(member);

        return new RegistrationResponse { Id = user.Id };

    }
}