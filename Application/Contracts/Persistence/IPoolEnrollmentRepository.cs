using Domain;

namespace Application.Contracts.Persistence;

public interface IPoolEnrollmentRepository : IGenericRepository<PoolEnrollmentRequest>
{
    Task<List<PoolEnrollmentRequest>> GetAllByMemberIdWithDataAsync(int memberId);
    Task<List<PoolEnrollmentRequest>> GetAllWithDataAsync();
}