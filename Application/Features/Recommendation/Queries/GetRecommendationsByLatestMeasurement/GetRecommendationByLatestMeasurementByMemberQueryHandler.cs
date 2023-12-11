using System.Text;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Recommendation.Queries.Shared;
using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsByLatestMeasurement;

public class GetRecommendationByLatestMeasurementByMemberQueryHandler : IRequestHandler<GetRecommendationByLatestMeasurementByMemberQuery, GetRecommendationsResponse>
{
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IMeasurementRepository _measurementRepository;

    public GetRecommendationByLatestMeasurementByMemberQueryHandler(IUserService userService, IMemberRepository memberRepository,
        IRecommendationRepository recommendationRepository, IMeasurementRepository measurementRepository)
    {
        _userService = userService;
        _memberRepository = memberRepository;
        _recommendationRepository = recommendationRepository;
        _measurementRepository = measurementRepository;
    }

    public async Task<GetRecommendationsResponse> Handle(GetRecommendationByLatestMeasurementByMemberQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var measurement = await _measurementRepository.GetLatestMeasurementByMember(member.Id);
        if (measurement is null)
            throw new NotFoundException("No measurements found for this member.");
        
        var sharedMethods = new SharedMethods(_recommendationRepository);
        var result = new GetRecommendationsResponse { Recommendations = await sharedMethods.GenerateRecommendations(measurement, member.Sex) };
        return result;
    }

    
}