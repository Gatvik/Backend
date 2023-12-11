using System.Text;
using Application.Contracts.Persistence;

namespace Application.Features.Recommendation.Queries.Shared;

public class SharedMethods
{
    private readonly IRecommendationRepository _recommendationRepository;

    public SharedMethods(IRecommendationRepository recommendationRepository)
    {
        _recommendationRepository = recommendationRepository;
    }

    public async Task<List<RecommendationDto>> GenerateRecommendations(Domain.Measurement measurement, string sex)
    {
        List<RecommendationDto> recommendations = new();

        recommendations.Add(new RecommendationDto
        {
            Theme = "Body mass index",
            Recommendation = measurement.BodyMassIndex switch
            {
                <= 16.0d => await GetRecommendationByKey("ExtremelyLowBMI"),
                > 16.0d and <= 18.5d => await GetRecommendationByKey("LowBMI"),
                > 18.5d and <= 25.0d => await GetRecommendationByKey("NormalBMI"),
                > 25.0d and <= 30.0d => await GetRecommendationByKey("HighBMI"),
                > 30.0d => await GetRecommendationByKey("ExtremelyHighBMI")
            }
        });

        recommendations.Add(new RecommendationDto
        {
            Theme = "Level of stress",
            Recommendation = measurement.LevelOfStress switch
            {
                <= 107.5d => await GetRecommendationByKey("NormalStress"),
                > 107.5d => await GetRecommendationByKey("HighStress")
            }
        });

        var upperPressure = measurement.UpperPressure;
        var lowerPressure = measurement.LowerPressure;
        var pressureRecommendation = new RecommendationDto { Theme = "Blood pressure" };

        if (upperPressure < 125)
        {
            if (lowerPressure < 75)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("NormalPressure");
            else
                pressureRecommendation.Recommendation = await GetRecommendationByKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }
        else if (upperPressure <= 135)
        {
            if (lowerPressure < 75)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("NormalPressure");
            else
                pressureRecommendation.Recommendation = await GetRecommendationByKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }
        else
        {
            if (lowerPressure < 75)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Recommendation = await GetRecommendationByKey("NormalPressure");
            else
                pressureRecommendation.Recommendation = await GetRecommendationByKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }

        if (sex is "Male")
        {
            recommendations.Add(new RecommendationDto
            {
                Theme = "Fat percentage",
                Recommendation = measurement.FatPercentage switch
                {
                    < 14.0d => await GetRecommendationByKey("LowFat"),
                    >= 14.0d and <= 20.0d => await GetRecommendationByKey("NormalFat"),
                    > 20.0d => await GetRecommendationByKey("HighFat"),
                }
            });
            
            recommendations.Add(new RecommendationDto
            {
                Theme = "Muscle percentage",
                Recommendation = measurement.MusclePercentage switch
                {
                    < 35.0d => await GetRecommendationByKey("LowMuscle"),
                    >= 35.0d and <= 45.0d => await GetRecommendationByKey("NormalMuscle"),
                    > 45.0d => await GetRecommendationByKey("HighMuscle"),
                }
            });
            
            

            // recommendations.AppendLine((measurement.UpperPressure, measurement.LowerPressure) switch
            // {
            //     (< 125, < 75) => await GetRecommendationByKey("LowPressure"),
            //     (>= 125 and <= 135, >= 75 and <= 89) => await GetRecommendationByKey("NormalPressure"),
            //     (> 140, 89) => await GetRecommendationByKey("HighPressure"),
            // });
        }
        else if (sex is "Female")
        {
            recommendations.Add(new RecommendationDto
            {
                Theme = "Fat percentage",
                Recommendation = measurement.FatPercentage switch
                {
                    < 19.0d => await GetRecommendationByKey("LowFat"),
                    >= 19.0d and <= 25.0d => await GetRecommendationByKey("NormalFat"),
                    > 25.0d => await GetRecommendationByKey("HighFat"),
                }
            });
            
            recommendations.Add(new RecommendationDto
            {
                Theme = "Muscle percentage",
                Recommendation = measurement.FatPercentage switch
                {
                    < 25.0d => await GetRecommendationByKey("LowMuscle"),
                    >= 25.0d and <= 35.0d => await GetRecommendationByKey("NormalMuscle"),
                    > 35.0d => await GetRecommendationByKey("HighMuscle"),
                }
            });

            // recommendations.AppendLine((measurement.UpperPressure, measurement.LowerPressure) switch
            // {
            //     (< 125, < 75) => await GetRecommendationByKey("LowPressure"),
            //     (>= 125 and <= 135, >= 75 and <= 87) => await GetRecommendationByKey("NormalPressure"),
            //     (> 135, > 87) => await GetRecommendationByKey("HighPressure"),
            // });
        }

        return recommendations;
    }

    private async Task<string> GetRecommendationByKey(string key)
    {
        var recommendation = await _recommendationRepository.GetRecommendationByKey(key);
        if (recommendation is null)
            throw new ArgumentException($"Recommendation with key {key} was not found.");

        return recommendation.Description;
    }
}