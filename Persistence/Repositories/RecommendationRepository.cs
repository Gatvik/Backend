using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class RecommendationRepository : GenericRepository<Recommendation>, IRecommendationRepository
{
    public RecommendationRepository(DataContext context) : base(context)
    {
    }

    public async Task<bool> IsKeyValid(string key)
    {
        return await GetByPredicateAsync(r => r.Key == key) != null;
    }
}