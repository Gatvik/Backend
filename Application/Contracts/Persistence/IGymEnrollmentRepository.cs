using Domain;

namespace Application.Contracts.Persistence;

public interface IGymEnrollmentRepository : IGenericRepository<GymEnrollmentRequest>
{
    Task<IReadOnlyList<GymEnrollmentRequest>> GetAllByMemberIdAsync(int memberId);
}