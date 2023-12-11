using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(DataContext context) : base(context)
    {
    }
    
    public Task<Member?> GetByIdentityIdAsync(string identityId)
    {
        return GetByPredicateAsync(m => m.IdentityId == identityId);
    }
    
    public Task<Member?> GetWithGymByIdentityIdAsync(string identityId)
    {
        return Context.Members
            .AsNoTracking()
            .Include(m => m.Gym)
            .FirstOrDefaultAsync(m => m.IdentityId == identityId);
    }
}