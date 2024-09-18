using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Pool.Commands.UpdatePool;

public class UpdatePoolCommandHandler : IRequestHandler<UpdatePoolCommand, Unit>
{
    private readonly IPoolRepository _poolRepository;

    public UpdatePoolCommandHandler(IPoolRepository poolRepository)
    {
        _poolRepository = poolRepository;
    }
    
    public async Task<Unit> Handle(UpdatePoolCommand request, CancellationToken cancellationToken)
    {
        var gym = await _poolRepository.GetByIdAsync(request.Id);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Pool), request.Id);
        
        gym.Name = request.Name;
        gym.Address = request.Address;
        gym.City = request.City;
        gym.Country = request.Country;
        gym.Description = request.Description;
        
        await _poolRepository.UpdateAsync(gym);

        return Unit.Value;
    }
}