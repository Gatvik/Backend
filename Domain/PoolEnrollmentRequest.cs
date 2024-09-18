using Domain.Common;

namespace Domain;

public class PoolEnrollmentRequest : BaseEntity
{
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public int PoolId { get; set; }
    public Pool Pool { get; set; }
    public DateTime EnrollmentDateTime { get; set; }
}