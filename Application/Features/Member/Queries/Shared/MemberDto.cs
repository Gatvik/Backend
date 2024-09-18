using Application.Features.Pool.Queries.Shared;

namespace Application.Features.Member.Queries.Shared;

public class MemberDto
{
    public int Id { get; set; }
    public string IdentityId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public PoolDto? Pool { get; set; }
}