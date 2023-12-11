using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Member.Commands.EnrollMemberToGym;

public class EnrollMemberToGymCommandHandler : IRequestHandler<EnrollMemberToGymCommand, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IGymRepository _gymRepository;

    public EnrollMemberToGymCommandHandler(IGymRepository gymRepository, IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        _gymRepository = gymRepository;
    }
    
    public async Task<Unit> Handle(EnrollMemberToGymCommand request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIdAsync(request.MemberId);
        if (member is null)
            throw new NotFoundException(nameof(Domain.Member), request.MemberId);
        
        var gym = await _gymRepository.GetByIdAsync(request.GymId);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Gym), request.GymId);
        
        member.GymId = gym.Id;
        await _memberRepository.UpdateAsync(member);

        return Unit.Value;
    }
}