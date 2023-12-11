using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.GymEnrollment.Commands.DeleteEnrollment;

public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, Unit>
{
    private readonly IGymEnrollmentRepository _gymEnrollmentRepository;

    public DeleteEnrollmentCommandHandler(IGymEnrollmentRepository gymEnrollmentRepository)
    {
        _gymEnrollmentRepository = gymEnrollmentRepository;
    }
    
    public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var gymEnrollment = await _gymEnrollmentRepository.GetByIdAsync(request.GymEnrollmentId);
        if (gymEnrollment is null)
            throw new NotFoundException(nameof(Domain.GymEnrollmentRequest), request.GymEnrollmentId);
        
        await _gymEnrollmentRepository.DeleteAsync(gymEnrollment);
        
        return Unit.Value;
    }
}