using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Measurement.Queries.Shared;
using AutoMapper;
using MediatR;

namespace Application.Features.Measurement.Queries.GetMeasurementsByMember;

public class GetMeasurementsByMemberQueryHandler : IRequestHandler<GetMeasurementsByMemberQuery, List<MeasurementDto>>
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public GetMeasurementsByMemberQueryHandler(IMeasurementRepository measurementRepository,
        IUserService userService, IMapper mapper, IMemberRepository memberRepository)
    {
        _measurementRepository = measurementRepository;
        _userService = userService;
        _mapper = mapper;
        _memberRepository = memberRepository;
    }

    public async Task<List<MeasurementDto>> Handle(GetMeasurementsByMemberQuery request,
        CancellationToken cancellationToken)
    {
        string userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var measurementList = await _measurementRepository.GetMeasurementsByMember(member.Id);
        
        if (measurementList.Count == 0)
            throw new NotFoundException("No measurements found for this member.");
        
        var measurementDtoList = _mapper.Map<List<MeasurementDto>>(measurementList);
        return measurementDtoList;
    }
}