using FluentValidation;

namespace Application.Features.Member.Commands.UpdateMember;

public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .MaximumLength(64).WithMessage("{PropertyName} must be fewer than {ComparisonValue} characters");
        
        RuleFor(m => m.LastName)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .MaximumLength(64).WithMessage("{PropertyName} must be fewer than {ComparisonValue} characters");
    }
}