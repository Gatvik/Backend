using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Pool.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Pool.Queries.GetAllPools;

public class GetAllPoolsQueryHandler : IRequestHandler<GetAllPoolsQuery, List<PoolDto>>
{
    private readonly IPoolRepository _poolRepository;
    private readonly IMapper _mapper;

    public GetAllPoolsQueryHandler(IPoolRepository poolRepository, IMapper mapper)
    {
        _poolRepository = poolRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PoolDto>> Handle(GetAllPoolsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _poolRepository.GetAllAsync();
        if (gyms.Count == 0)
            throw new NotFoundException("No pools found.");
        
        return _mapper.Map<List<PoolDto>>(gyms);
    }
}