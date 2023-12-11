using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Commands.CreateGym;

public class CreateGymCommandHandler : IRequestHandler<CreateGym.CreateGymCommand, int>
{
    private readonly IGymRepository _gymRepository;
    private readonly IMapper _mapper;

    public CreateGymCommandHandler(IGymRepository gymRepository, IMapper mapper)
    {
        _gymRepository = gymRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateGym.CreateGymCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGymCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid data for creating a gym", validationResult);
        
        var gym = _mapper.Map<Domain.Gym>(request);
        
        await _gymRepository.CreateAsync(gym);

        return gym.Id;

    }
}