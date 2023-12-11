using Domain.Common;

namespace Domain;

public class Member : BaseEntity
{
    public string IdentityId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public int? GymId { get; set; }
    public Gym? Gym { get; set; }
    public ICollection<Measurement>? Measurements { get; set; }
}