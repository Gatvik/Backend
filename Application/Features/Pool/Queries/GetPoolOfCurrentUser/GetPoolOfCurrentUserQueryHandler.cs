using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Pool.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Pool.Queries.GetPoolOfCurrentUser;

public class GetPoolOfCurrentUserQueryHandler : IRequestHandler<GetPoolOfCurrentUserQuery, PoolDto>
{
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public GetPoolOfCurrentUserQueryHandler(IUserService userService, IMemberRepository memberRepository, IMapper mapper)
    {
        _userService = userService;
        _memberRepository = memberRepository;
        _mapper = mapper;
    }
    
    public async Task<PoolDto> Handle(GetPoolOfCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetWithGymByIdentityIdAsync(userId);
        
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        if (member.Pool is null)
            throw new BadRequestException("Member not enrolled to gym");

        return _mapper.Map<PoolDto>(member.Pool);
    }
}