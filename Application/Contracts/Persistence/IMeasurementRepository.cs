using Domain;

namespace Application.Contracts.Persistence;

public interface IMeasurementRepository : IGenericRepository<Measurement>
{
    Task<IReadOnlyList<Measurement>> GetMeasurementsByMember(int memberId);

    Task<Measurement?> GetLatestMeasurementByMember(int memberId);
}