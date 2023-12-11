using MediatR;

namespace Application.Features.Member.Commands.DeleteMemberById;

public record DeleteMemberByIdCommand(string IdentityId) : IRequest<Unit>;