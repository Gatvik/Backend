using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class PoolEnrollmentRepository : GenericRepository<PoolEnrollmentRequest>, IPoolEnrollmentRepository
{
    public PoolEnrollmentRepository(DataContext context) : base(context)
    {
    }
    
    public Task<List<PoolEnrollmentRequest>> GetAllByMemberIdWithDataAsync(int memberId)
    {
        return Context.PoolEnrollmentRequests
            .AsNoTracking()
            .Include(x => x.Member)
            .AsNoTracking()
            .Include(x => x.Pool)
            .AsNoTracking()
            .Where(x => x.MemberId == memberId)
            .ToListAsync();
    }

    public Task<List<PoolEnrollmentRequest>> GetAllWithDataAsync()
    {
        return Context.PoolEnrollmentRequests
            .AsNoTracking()
            .Include(x => x.Member)
            .AsNoTracking()
            .Include(x => x.Pool)
            .AsNoTracking()
            .ToListAsync();
    }
}