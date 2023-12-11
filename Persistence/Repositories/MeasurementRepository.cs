using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class MeasurementRepository : GenericRepository<Measurement>, IMeasurementRepository
{
    public MeasurementRepository(DataContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Measurement>> GetMeasurementsByMember(int memberId)
    {
        return GetAllByPredicateAsync(m => m.MemberId == memberId);
    }
}