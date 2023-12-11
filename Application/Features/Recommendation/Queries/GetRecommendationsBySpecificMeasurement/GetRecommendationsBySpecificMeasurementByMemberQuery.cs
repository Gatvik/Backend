using Application.Features.Recommendation.Queries.Shared;
using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsBySpecificMeasurement;

public record GetRecommendationsBySpecificMeasurementByMemberQuery(int MeasurementId) : IRequest<GetRecommendationsResponse>;