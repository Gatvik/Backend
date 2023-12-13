using MediatR;

namespace Application.Features.Member.Commands.UpdateMember;

public class UpdateMemberCommand : IRequest<Unit>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}