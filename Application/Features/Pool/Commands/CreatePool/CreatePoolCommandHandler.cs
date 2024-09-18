using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Pool.Commands.CreatePool;

public class CreatePoolCommandHandler : IRequestHandler<CreatePoolCommand, int>
{
    private readonly IPoolRepository _poolRepository;
    private readonly IMapper _mapper;

    public CreatePoolCommandHandler(IPoolRepository poolRepository, IMapper mapper)
    {
        _poolRepository = poolRepository;
        _mapper = mapper;
    }


    public async Task<int> Handle(CreatePoolCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePoolCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid data for creating a gym", validationResult);
        
        var gym = _mapper.Map<Domain.Pool>(request);
        
        await _poolRepository.CreateAsync(gym);

        return gym.Id;

    }
}