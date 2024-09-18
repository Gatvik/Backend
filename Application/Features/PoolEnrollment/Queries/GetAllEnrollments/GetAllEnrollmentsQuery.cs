using Application.Features.PoolEnrollment.Queries.Shared;
using MediatR;

namespace Application.Features.PoolEnrollment.Queries.GetAllEnrollments;

public record GetAllEnrollmentsQuery() : IRequest<List<PoolEnrollmentDto>>;