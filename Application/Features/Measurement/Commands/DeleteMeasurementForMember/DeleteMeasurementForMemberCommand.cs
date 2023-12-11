using MediatR;

namespace Application.Features.Measurement.Commands.DeleteMeasurementForMember;

public record DeleteMeasurementForMemberCommand(int Id) : IRequest<Unit>;