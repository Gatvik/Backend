using Application.Features.Member.Queries.Shared;
using Application.Features.Pool.Queries.Shared;

namespace Application.Features.PoolEnrollment.Queries.Shared;

public class PoolEnrollmentDto
{
    public int Id { get; set; }
    public MemberDto Member { get; set; }
    public PoolDto Pool { get; set; }
    public DateTime EnrollmentDateTime { get; set; }
}