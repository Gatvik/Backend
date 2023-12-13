using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Gym.Commands.DeleteGym;

public class DeleteGymCommandHandler : IRequestHandler<DeleteGymCommand, Unit>
{
    private readonly IGymRepository _gymRepository;

    public DeleteGymCommandHandler(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }
    
    public async Task<Unit> Handle(DeleteGymCommand request, CancellationToken cancellationToken)
    {
        var gym = await _gymRepository.GetByIdAsync(request.Id);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Gym), request.Id);
        
        await _gymRepository.DeleteAsync(gym);

        return Unit.Value;
    }
}