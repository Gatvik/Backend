using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.PoolEnrollment.Commands.DeleteEnrollment;

public class DeleteEnrollmentCommandHandler : IRequestHandler<DeleteEnrollmentCommand, Unit>
{
    private readonly IPoolEnrollmentRepository _poolEnrollmentRepository;

    public DeleteEnrollmentCommandHandler(IPoolEnrollmentRepository poolEnrollmentRepository)
    {
        _poolEnrollmentRepository = poolEnrollmentRepository;
    }
    
    public async Task<Unit> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var gymEnrollment = await _poolEnrollmentRepository.GetByIdAsync(request.PoolEnrollmentId);
        if (gymEnrollment is null)
            throw new NotFoundException(nameof(Domain.PoolEnrollmentRequest), request.PoolEnrollmentId);
        
        await _poolEnrollmentRepository.DeleteAsync(gymEnrollment);
        
        return Unit.Value;
    }
}