using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.GymEnrollment.Commands.SendRequestToEnroll;

public class SendRequestToEnrollCommandHandler : IRequestHandler<SendRequestToEnrollCommand, int>
{
    private readonly ILogger<SendRequestToEnrollCommandHandler> _logger;
    private readonly IGymRepository _gymRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IGymEnrollmentRepository _gymEnrollmentRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public SendRequestToEnrollCommandHandler(ILogger<SendRequestToEnrollCommandHandler> logger, IGymRepository gymRepository, IMemberRepository memberRepository,
        IGymEnrollmentRepository gymEnrollmentRepository, IUserService userService, IMapper mapper)
    {
        _logger = logger;
        _gymRepository = gymRepository;
        _memberRepository = memberRepository;
        _gymEnrollmentRepository = gymEnrollmentRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<int> Handle(SendRequestToEnrollCommand request, CancellationToken cancellationToken)
    {
        var id = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(id);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var gym = await _gymRepository.GetByIdAsync(request.GymId);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Gym), request.GymId);

        var gymEnrollment = new GymEnrollmentRequest { GymId = gym.Id, MemberId = member.Id};
        gymEnrollment.EnrollmentDateTime = DateTime.UtcNow;
        
        await _gymEnrollmentRepository.CreateAsync(gymEnrollment);

        return gymEnrollment.Id;
    }
}