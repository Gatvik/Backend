using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Member.Commands.LeaveFromGym;

public class LeaveFromGymCommandHandler : IRequestHandler<LeaveFromGymCommand, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUserService _userService;

    public LeaveFromGymCommandHandler(IMemberRepository memberRepository, IUserService userService)
    {
        _memberRepository = memberRepository;
        _userService = userService;
    }

    public async Task<Unit> Handle(LeaveFromGymCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        member.GymId = null;
        await _memberRepository.UpdateAsync(member);
        
        return Unit.Value;
    }
}