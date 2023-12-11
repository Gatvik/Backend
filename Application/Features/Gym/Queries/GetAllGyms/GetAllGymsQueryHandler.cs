using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Gym.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Queries.GetAllGyms;

public class GetAllGymsQueryHandler : IRequestHandler<GetAllGymsQuery, List<GymDto>>
{
    private readonly IGymRepository _gymRepository;
    private readonly IMapper _mapper;

    public GetAllGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
    {
        _gymRepository = gymRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GymDto>> Handle(GetAllGymsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _gymRepository.GetAllAsync();
        if (gyms.Count == 0)
            throw new NotFoundException("No gyms found.");
        
        return _mapper.Map<List<GymDto>>(gyms);
    }
}