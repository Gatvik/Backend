using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Recommendation.Queries.Shared;
using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsBySpecificMeasurement;

public class GetRecommendationsBySpecificMeasurementByMemberQueryHandler
    : IRequestHandler<GetRecommendationsBySpecificMeasurementByMemberQuery, List<RecommendationDto>>
{
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IRecommendationRepository _recommendationRepository;

    public GetRecommendationsBySpecificMeasurementByMemberQueryHandler(IUserService userService,
        IMemberRepository memberRepository, IMeasurementRepository measurementRepository,
        IRecommendationRepository recommendationRepository)
    {
        _userService = userService;
        _memberRepository = memberRepository;
        _measurementRepository = measurementRepository;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<List<RecommendationDto>> Handle(GetRecommendationsBySpecificMeasurementByMemberQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");

        var measurement = await _measurementRepository.GetByIdAsync(request.MeasurementId);
        if (measurement is null)
            throw new NotFoundException("No measurements found for this member.");

        var sharedMethods = new SharedMethods(_recommendationRepository);
        var result = await sharedMethods.GenerateRecommendations(measurement, member.Sex);
        return result;
    }
}