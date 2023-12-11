using Application.Features.Measurement.Queries.Shared;
using MediatR;

namespace Application.Features.Measurement.Queries.GetMeasurementById;

public record GetMeasurementByIdQuery(int Id) : IRequest<MeasurementDto>;