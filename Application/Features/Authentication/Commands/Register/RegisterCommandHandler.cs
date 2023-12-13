using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Authentication.Shared;
using Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMemberRepository _memberRepository;
    private readonly JwtSettings _jwtSettings;

    public RegisterCommandHandler(UserManager<IdentityUser> userManager, IMemberRepository memberRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _memberRepository = memberRepository;
        _jwtSettings = jwtSettings.Value;
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
        
        JwtSecurityToken jwtSecurityToken = await new JwtTokenGenerator(_userManager, _jwtSettings).GenerateTokenAsync(user);
        
        return new RegistrationResponse
        {
            Id = user.Id, 
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };

    }
}