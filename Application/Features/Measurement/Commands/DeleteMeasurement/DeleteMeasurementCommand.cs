using MediatR;

namespace Application.Features.Measurement.Commands.DeleteMeasurement;

public record DeleteMeasurementCommand(int Id) : IRequest<Unit>;