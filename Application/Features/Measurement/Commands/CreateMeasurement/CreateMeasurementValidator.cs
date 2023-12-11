using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Measurement.Commands.CreateMeasurement;

public class CreateMeasurementValidator : AbstractValidator<CreateMeasurementCommand>
{
    public CreateMeasurementValidator()
    {
        
        // RuleFor(m => m.MemberId)
        //     .MustAsync(MemberMustExist);
        
        RuleFor(m => m.Height)
            .GreaterThan(0.0d).WithMessage("{PropertyName} must be greater than 0.0")
            .LessThanOrEqualTo(300.0d).WithMessage("{PropertyName} must be less than or equal to 300.0");
        
        RuleFor(m => m.Weight)
            .GreaterThan(0.0d).WithMessage("{PropertyName} must be greater than or equal to 0.0")
            .LessThanOrEqualTo(300.0d).WithMessage("{PropertyName} must be less than or equal to 300.0");

        RuleFor(m => m.FatPercentage)
            .GreaterThan(0.0d).WithMessage("{PropertyName} must be greater than 0.0")
            .LessThanOrEqualTo(100.0d).WithMessage("{PropertyName} must be less than or equal to 100.0");
        
        RuleFor(m => m.MusclePercentage)
            .GreaterThan(0.0d).WithMessage("{PropertyName} must be greater than 0.0")
            .LessThanOrEqualTo(100.0d).WithMessage("{PropertyName} must be less than or equal to 100.0");
        
        RuleFor(m => m.UpperPressure)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .LessThanOrEqualTo(250).WithMessage("{PropertyName} must be less than or equal to 250");
    }

    // private async Task<bool> MemberMustExist(int memberId, CancellationToken cts)
    // {
    //     var member = await _memberRepository.GetByIdAsync(memberId);
    //     
    //     return member != null;
    // }
}