using MediatR;

namespace Application.Features.Member.Commands.EnrollMemberToPool;

public record EnrollMemberToPoolCommand(int MemberId, int PoolId) : IRequest<Unit>;