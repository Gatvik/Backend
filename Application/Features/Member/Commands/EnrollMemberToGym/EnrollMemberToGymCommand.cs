using MediatR;

namespace Application.Features.Member.Commands.EnrollMemberToGym;

public record EnrollMemberToGymCommand(int MemberId, int GymId) : IRequest<Unit>;