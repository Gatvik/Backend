using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsByLatestMeasurement;

public record GetRecommendationByMemberQuery : IRequest<GetRecommendationsResponse>;