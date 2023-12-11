using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Member.Commands.DeleteMemberById;

public class DeleteMemberByIdCommandHandler : IRequestHandler<DeleteMemberByIdCommand, Unit>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMemberRepository _memberRepository;
    private readonly IUserService _userService;

    public DeleteMemberByIdCommandHandler(UserManager<IdentityUser> userManager, IMemberRepository memberRepository, IUserService userService)
    {
        _userManager = userManager;
        _memberRepository = memberRepository;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(DeleteMemberByIdCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var user = await _userManager.FindByIdAsync(userId);
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (user == null || member == null)
            throw new NotFoundException("Impossible exception, but user and member not binded");
        
        
        await _userManager.DeleteAsync(user);
        await _memberRepository.DeleteAsync(member);
        
        return Unit.Value;
    }
}