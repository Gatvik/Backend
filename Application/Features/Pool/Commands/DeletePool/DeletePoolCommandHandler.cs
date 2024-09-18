using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Pool.Commands.DeletePool;

public class DeletePoolCommandHandler : IRequestHandler<DeletePoolCommand, Unit>
{
    private readonly IPoolRepository _poolRepository;

    public DeletePoolCommandHandler(IPoolRepository poolRepository)
    {
        _poolRepository = poolRepository;
    }
    
    public async Task<Unit> Handle(DeletePoolCommand request, CancellationToken cancellationToken)
    {
        var gym = await _poolRepository.GetByIdAsync(request.Id);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Pool), request.Id);
        
        await _poolRepository.DeleteAsync(gym);

        return Unit.Value;
    }
}