using MediatR;

namespace Application.Features.Measurement.Commands.CreateMeasurement;

public class CreateMeasurementCommand : IRequest<int>
{
    public double Height { get; set; }
    public double Weight { get; set; }
    public double FatPercentage { get; set; }
    public double MusclePercentage { get; set; }
    public int UpperPressure { get; set; }
    public int LowerPressure { get; set; }
}