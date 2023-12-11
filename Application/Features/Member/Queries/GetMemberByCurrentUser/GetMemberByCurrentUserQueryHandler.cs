using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Member.Queries.GetMemberByIdentityId;
using Application.Features.Member.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Member.Queries.GetMemberByCurrentUser;

public class GetMemberByCurrentUserQueryHandler : IRequestHandler<GetMemberByCurrentUserQuery, MemberDto>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetMemberByCurrentUserQueryHandler(IMemberRepository memberRepository, IUserService userService, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<MemberDto> Handle(GetMemberByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(currentUserId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        return _mapper.Map<MemberDto>(member);
    }
}