using Domain.Common;

namespace Domain;

public class Measurement : BaseEntity
{
    public DateTime DateAndTime { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double FatPercentage { get; set; }
    public double MusclePercentage { get; set; }
    public int UpperPressure { get; set; }
    public int LowerPressure { get; set; }
    
    public double BodyMassIndex { get; set; }
    public double LevelOfStress { get; set; }
    
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;
}