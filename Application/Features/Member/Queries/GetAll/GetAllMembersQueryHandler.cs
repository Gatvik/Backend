using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Member.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Member.Queries.GetAll;

public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, List<MemberDto>>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public GetAllMembersQueryHandler(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }
    
    public async Task<List<MemberDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await _memberRepository.GetAllAsync();
        if (members.Count == 0)
            throw new NotFoundException("Members not found");

        return _mapper.Map<List<MemberDto>>(members);
    }
}