using System.Text;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Recommendation.Queries.GetRecommendationsByLatestMeasurement;

public class GetRecommendationByMemberQueryHandler : IRequestHandler<GetRecommendationByMemberQuery, GetRecommendationsResponse>
{
    private readonly IUserService _userService;
    private readonly IMemberRepository _memberRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IMeasurementRepository _measurementRepository;

    public GetRecommendationByMemberQueryHandler(IUserService userService, IMemberRepository memberRepository,
        IRecommendationRepository recommendationRepository, IMeasurementRepository measurementRepository)
    {
        _userService = userService;
        _memberRepository = memberRepository;
        _recommendationRepository = recommendationRepository;
        _measurementRepository = measurementRepository;
    }

    public async Task<GetRecommendationsResponse> Handle(GetRecommendationByMemberQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var member = await _memberRepository.GetByIdentityIdAsync(userId);
        if (member is null)
            throw new NotFoundException("Member don't binded to identity user... Please contact with admin.");
        
        var measurement = await _measurementRepository.GetLatestMeasurementByMember(member.Id);
        if (measurement is null)
            throw new NotFoundException("No measurements found for this member.");

        var result = new GetRecommendationsResponse { Recommendations = await GenerateRecommendations(measurement, member.Sex) };
        return result;
    }

    private async Task<string> GenerateRecommendations(Domain.Measurement measurement, string sex)
    {
        StringBuilder recommendations = new();
        
        recommendations.AppendLine(measurement.BodyMassIndex switch
        {
            <= 16.0d => await GetRecommendationByKey("ExtremelyLowBMI"),
            > 16.0d and <= 18.5d => await GetRecommendationByKey("LowBMI"),
            > 18.5d and <= 25.0d => await GetRecommendationByKey("NormalBMI"),
            > 25.0d and <= 30.0d => await GetRecommendationByKey("HighBMI"),
            > 30.0d => await GetRecommendationByKey("ExtremelyHighBMI")
        });

        recommendations.AppendLine(measurement.LevelOfStress switch
        {
            <= 107.5d => await GetRecommendationByKey("NormalStress"),
            > 107.5d => await GetRecommendationByKey("HighStress")
        });
        
        if (sex is "Male")
        {
            recommendations.AppendLine(measurement.FatPercentage switch
            {
                < 14.0d => await GetRecommendationByKey("LowFat"),
                >= 14.0d and <= 20.0d => await GetRecommendationByKey("NormalFat"),
                > 20.0d => await GetRecommendationByKey("HighFat"),
            });

            recommendations.AppendLine(measurement.MusclePercentage switch
            {
                < 35.0d => await GetRecommendationByKey("LowMuscle"),
                >= 35.0d and <= 45.0d => await GetRecommendationByKey("NormalMuscle"),
                > 45.0d => await GetRecommendationByKey("HighMuscle"),
            });
            
            recommendations.AppendLine(measurement.UpperPressure switch
            {
                < 125 => await GetRecommendationByKey("LowUpperPressure"),
                >= 125 and <= 135 => await GetRecommendationByKey("NormalUpperPressure"),
                > 140 => await GetRecommendationByKey("HighUpperPressure"),
            });
        }
        else if (sex is "Female")
        {
            recommendations.AppendLine(measurement.FatPercentage switch
            {
                < 19.0d => await GetRecommendationByKey("LowFat"),
                >= 19.0d and <= 25.0d => await GetRecommendationByKey("NormalFat"),
                > 25.0d => await GetRecommendationByKey("HighFat"),
            });
            
            recommendations.AppendLine(measurement.MusclePercentage switch
            {
                < 25.0d => await GetRecommendationByKey("LowMuscle"),
                >= 25.0d and <= 35.0d => await GetRecommendationByKey("NormalMuscle"),
                > 35.0d => await GetRecommendationByKey("HighMuscle"),
            });
            
            recommendations.AppendLine(measurement.UpperPressure switch
            {
                < 125 => await GetRecommendationByKey("LowUpperPressure"),
                >= 125 and <= 135 => await GetRecommendationByKey("NormalUpperPressure"),
                > 135 => await GetRecommendationByKey("HighUpperPressure"),
            });
        }

        return recommendations.ToString();
    }
    
    private async Task<string> GetRecommendationByKey(string key)
    {
        var recommendation = await _recommendationRepository.GetRecommendationByKey(key);
        if (recommendation is null)
            throw new ArgumentException($"Recommendation with key {key} was not found.");
        
        return recommendation.Description;
    }
}