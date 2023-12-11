using Application.Features.GymEnrollment.Queries.Shared;
using MediatR;

namespace Application.Features.GymEnrollment.Queries.GetAllEnrollments;

public record GetAllEnrollmentsQuery() : IRequest<List<GymEnrollmentDto>>;