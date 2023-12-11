using Domain;

namespace Application.Contracts.Persistence;

public interface IRecommendationRepository : IGenericRepository<Recommendation>
{
    Task<Recommendation?> GetRecommendationByKey(string key);
}