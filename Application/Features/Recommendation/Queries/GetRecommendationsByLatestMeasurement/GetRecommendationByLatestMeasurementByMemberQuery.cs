﻿using Application.Features.Recommendation.Queries.Shared;
using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsByLatestMeasurement;

public record GetRecommendationByLatestMeasurementByMemberQuery : IRequest<GetRecommendationsResponse>;