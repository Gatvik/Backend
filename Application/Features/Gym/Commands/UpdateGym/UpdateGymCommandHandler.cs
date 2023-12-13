using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Gym.Commands.UpdateGym;

public class UpdateGymCommandHandler : IRequestHandler<UpdateGymCommand, Unit>
{
    private readonly IGymRepository _gymRepository;

    public UpdateGymCommandHandler(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }
    
    public async Task<Unit> Handle(UpdateGymCommand request, CancellationToken cancellationToken)
    {
        var gym = await _gymRepository.GetByIdAsync(request.Id);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Gym), request.Id);
        
        gym.Name = request.Name;
        gym.Address = request.Address;
        gym.City = request.City;
        gym.Country = request.Country;
        gym.Description = request.Description;
        
        await _gymRepository.UpdateAsync(gym);

        return Unit.Value;
    }
}