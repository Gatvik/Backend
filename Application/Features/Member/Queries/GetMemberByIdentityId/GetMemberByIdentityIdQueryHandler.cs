using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Member.Queries.GetMemberByIdentityId;

public class GetMemberByIdentityIdQueryHandler : IRequestHandler<GetMemberByIdentityQuery, MemberDto>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public GetMemberByIdentityIdQueryHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<MemberDto> Handle(GetMemberByIdentityQuery request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIdentityIdAsync(request.IdentityId);
        if (member is null)
            throw new NotFoundException($"{nameof(Member)} with identity id {request.IdentityId} was not found.");

        return _mapper.Map<MemberDto>(member);
    }
}