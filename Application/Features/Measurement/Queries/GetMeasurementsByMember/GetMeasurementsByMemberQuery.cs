using Application.Features.Measurement.Queries.Shared;
using MediatR;

namespace Application.Features.Measurement.Queries.GetMeasurementsByMember;

public record GetMeasurementsByMemberQuery() : IRequest<List<MeasurementDto>>;