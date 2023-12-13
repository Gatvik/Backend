using Domain.Common;

namespace Domain;

public class GymEnrollmentRequest : BaseEntity
{
    public int MemberId { get; set; }
    public int GymId { get; set; }
    public DateTime EnrollmentDateTime { get; set; }
}