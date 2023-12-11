using Application.Features.GymEnrollment.Queries.Shared;
using MediatR;

namespace Application.Features.GymEnrollment.Queries.GetEnrollmentsByMember;

public record GetEnrollmentsByMemberQuery : IRequest<List<GymEnrollmentDto>>;