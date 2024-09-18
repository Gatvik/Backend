using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Member.Commands.EnrollMemberToPool;

public class EnrollMemberToPoolCommandHandler : IRequestHandler<EnrollMemberToPoolCommand, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IPoolRepository _poolRepository;

    public EnrollMemberToPoolCommandHandler(IPoolRepository poolRepository, IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
        _poolRepository = poolRepository;
    }
    
    public async Task<Unit> Handle(EnrollMemberToPoolCommand request, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetByIdAsync(request.MemberId);
        if (member is null)
            throw new NotFoundException(nameof(Domain.Member), request.MemberId);
        
        var gym = await _poolRepository.GetByIdAsync(request.PoolId);
        if (gym is null)
            throw new NotFoundException(nameof(Domain.Pool), request.PoolId);
        
        member.PoolId = gym.Id;
        await _memberRepository.UpdateAsync(member);

        return Unit.Value;
    }
}