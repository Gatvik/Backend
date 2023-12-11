using Domain;

namespace Application.Contracts.Persistence;

public interface IMemberRepository : IGenericRepository<Member>
{
    Task<Member?> GetByIdentityIdAsync(string identityId);
    Task<Member?> GetWithGymByIdentityIdAsync(string identityId);
}