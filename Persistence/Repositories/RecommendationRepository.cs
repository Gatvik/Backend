using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class RecommendationRepository : GenericRepository<Recommendation>, IRecommendationRepository
{
    public RecommendationRepository(DataContext context) : base(context)
    {
    }

    public Task<Recommendation?> GetRecommendationByKey(string key)
    {
        return GetByPredicateAsync(r => r.Key == key);
    }
}