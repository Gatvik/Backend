using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GymEnrollmentRepository : GenericRepository<GymEnrollmentRequest>, IGymEnrollmentRepository
{
    public GymEnrollmentRepository(DataContext context) : base(context)
    {
    }
    
    public Task<IReadOnlyList<GymEnrollmentRequest>> GetAllByMemberIdAsync(int memberId)
    {
        return GetAllByPredicateAsync(x => x.MemberId == memberId);
    }
}