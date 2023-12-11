using FluentValidation;

namespace Application.Features.Gym.Commands.CreateGym;

public class CreateGymCommandValidator : AbstractValidator<CreateGym.CreateGymCommand>
{
    public CreateGymCommandValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        
        RuleFor(g => g.Address)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        
        RuleFor(g => g.City)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        
        RuleFor(g => g.Country)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        
        RuleFor(g => g.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
    }
}