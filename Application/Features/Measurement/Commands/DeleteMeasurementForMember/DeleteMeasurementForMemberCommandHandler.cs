using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Measurement.Commands.DeleteMeasurementForMember;

public class DeleteMeasurementForMemberCommandHandler : IRequestHandler<DeleteMeasurementForMemberCommand, Unit>
{
    private readonly IUserService _userService;
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IMapper _mapper;
    private readonly IMemberRepository _memberRepository;

    public DeleteMeasurementForMemberCommandHandler(IUserService userService,
        IMeasurementRepository measurementRepository, IMapper mapper, IMemberRepository memberRepository)
    {
        _userService = userService;
        _measurementRepository = measurementRepository;
        _mapper = mapper;
        _memberRepository = memberRepository;
    }

    public async Task<Unit> Handle(DeleteMeasurementForMemberCommand request, CancellationToken cancellationToken)
    {
        var measurementToDelete = await _measurementRepository.GetByIdAsync(request.Id);
        var currentUser = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(currentUser);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        
        if (measurementToDelete is null)
            throw new NotFoundException(nameof(Domain.Measurement), request.Id);
        
        if (measurementToDelete.MemberId != member.Id)
            throw new BadRequestException($"Measurement with id {request.Id} does not belong to user.");
        
        await _measurementRepository.DeleteAsync(measurementToDelete);

        return Unit.Value;  
    }
}