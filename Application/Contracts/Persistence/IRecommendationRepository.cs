using Domain;

namespace Application.Contracts.Persistence;

public interface IRecommendationRepository : IGenericRepository<Recommendation>
{
    Task<bool> IsKeyValid(string key);
}