namespace Application.Features.Member.Queries.Shared;

public class MemberDto
{
    public string IdentityId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public int? GymId { get; set; }
}