using Domain;

namespace Application.Contracts.Identity;

public interface IUserService
{
    // Task<List<Member>> GetMembers();
    // Task<Member> GetMember(string userId);
    public string UserId { get; }
}