using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Member.Commands.UpdateMember;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Unit>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUserService _userService;

    public UpdateMemberCommandHandler(IMemberRepository memberRepository, IUserService userService)
    {
        _memberRepository = memberRepository;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var validationResult = await new UpdateMemberCommandValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Data for updating member was invalid", validationResult);
        
        member.FirstName = request.FirstName;
        member.LastName = request.LastName;
        await _memberRepository.UpdateAsync(member);

        return Unit.Value;
    }
}