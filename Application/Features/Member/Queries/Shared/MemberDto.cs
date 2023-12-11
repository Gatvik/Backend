namespace Application.Features.Member.Queries.GetMemberByIdentityId;

public class MemberDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public int? GymId { get; set; }
}