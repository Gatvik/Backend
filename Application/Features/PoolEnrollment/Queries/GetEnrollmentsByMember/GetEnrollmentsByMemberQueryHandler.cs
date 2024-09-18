using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.PoolEnrollment.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.PoolEnrollment.Queries.GetEnrollmentsByMember;

public class GetEnrollmentsByMemberQueryHandler : IRequestHandler<GetEnrollmentsByMemberQuery, List<PoolEnrollmentDto>>
{
    private readonly IPoolEnrollmentRepository _poolEnrollmentRepository;
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public GetEnrollmentsByMemberQueryHandler(IPoolEnrollmentRepository poolEnrollmentRepository,
        IUserService userService, IMemberRepository memberRepository, IMapper mapper)
    {
        _poolEnrollmentRepository = poolEnrollmentRepository;
        _userService = userService;
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<List<PoolEnrollmentDto>> Handle(GetEnrollmentsByMemberQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var gymEnrollments = await _poolEnrollmentRepository.GetAllByMemberIdWithDataAsync(member.Id);
        if (gymEnrollments.Count == 0)
            throw new NotFoundException("No enrollments found for this member.");
        
        return _mapper.Map<List<PoolEnrollmentDto>>(gymEnrollments);
    }
}