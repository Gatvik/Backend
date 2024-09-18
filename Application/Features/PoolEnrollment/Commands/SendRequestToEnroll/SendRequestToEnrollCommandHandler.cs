using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.PoolEnrollment.Commands.SendRequestToEnroll;

public class SendRequestToEnrollCommandHandler : IRequestHandler<SendRequestToEnrollCommand, int>
{
    private readonly ILogger<SendRequestToEnrollCommandHandler> _logger;
    private readonly IPoolRepository _poolRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IPoolEnrollmentRepository _poolEnrollmentRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public SendRequestToEnrollCommandHandler(ILogger<SendRequestToEnrollCommandHandler> logger, IPoolRepository poolRepository, IMemberRepository memberRepository,
        IPoolEnrollmentRepository poolEnrollmentRepository, IUserService userService, IMapper mapper)
    {
        _logger = logger;
        _poolRepository = poolRepository;
        _memberRepository = memberRepository;
        _poolEnrollmentRepository = poolEnrollmentRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<int> Handle(SendRequestToEnrollCommand request, CancellationToken cancellationToken)
    {
        var id = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(id);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var gym = await _poolRepository.GetByIdAsync(request.PoolId);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Pool), request.PoolId);

        var gymEnrollment = new PoolEnrollmentRequest { PoolId = gym.Id, MemberId = member.Id};
        gymEnrollment.EnrollmentDateTime = DateTime.UtcNow;
        
        await _poolEnrollmentRepository.CreateAsync(gymEnrollment);

        return gymEnrollment.Id;
    }
}