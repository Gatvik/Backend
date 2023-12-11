using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Gym.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Queries.GetGymOfCurrentUser;

public class GetGymOfCurrentUserQueryHandler : IRequestHandler<GetGymOfCurrentUserQuery, GymDto>
{
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public GetGymOfCurrentUserQueryHandler(IUserService userService, IMemberRepository memberRepository, IMapper mapper)
    {
        _userService = userService;
        _memberRepository = memberRepository;
        _mapper = mapper;
    }
    
    public async Task<GymDto> Handle(GetGymOfCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetWithGymByIdentityIdAsync(userId);
        
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        if (member.Gym is null)
            throw new BadRequestException("Member not enrolled to gym");

        return _mapper.Map<GymDto>(member.Gym);
    }
}