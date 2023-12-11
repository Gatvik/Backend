using System.ComponentModel.DataAnnotations;
using Application.Models.Identity;
using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public class RegistrationCommand : IRequest<RegistrationResponse>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public DateOnly DateOfBirth { get; set; }
}