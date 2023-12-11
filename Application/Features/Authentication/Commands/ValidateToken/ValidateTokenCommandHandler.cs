using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Exceptions;
using Identity.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Authentication.Commands.ValidateToken;

public class ValidateTokenCommandHandler : IRequestHandler<ValidateTokenCommand, ValidateTokenResponse>
{
    private readonly JwtSettings _jwtSettings;

    public ValidateTokenCommandHandler(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    
    public async Task<ValidateTokenResponse> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key))
        };

        try
        {
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(request.Token, validationParameters, out _);
            
            var response = new ValidateTokenResponse()
            {
                Id = claimsPrincipal.FindFirstValue("uid")!,
                Email = claimsPrincipal.FindFirstValue(@"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")!,
            };

            return response;
        }
        catch
        {
            throw new BadRequestException("Invalid token.");
        }
    }
}