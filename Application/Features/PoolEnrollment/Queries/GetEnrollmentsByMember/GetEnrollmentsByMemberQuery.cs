using Application.Features.PoolEnrollment.Queries.Shared;
using MediatR;

namespace Application.Features.PoolEnrollment.Queries.GetEnrollmentsByMember;

public record GetEnrollmentsByMemberQuery : IRequest<List<PoolEnrollmentDto>>;