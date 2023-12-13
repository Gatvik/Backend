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
            Key = measurement.BodyMassIndex switch
            {
                <= 16.0d => await ValidateKey("ExtremelyLowBMI"),
                > 16.0d and <= 18.5d => await ValidateKey("LowBMI"),
                > 18.5d and <= 25.0d => await ValidateKey("NormalBMI"),
                > 25.0d and <= 30.0d => await ValidateKey("HighBMI"),
                > 30.0d => await ValidateKey("ExtremelyHighBMI")
            }
        });

        recommendations.Add(new RecommendationDto
        {
            Theme = "Level of stress",
            Key = measurement.LevelOfStress switch
            {
                <= 107.5d => await ValidateKey("NormalStress"),
                > 107.5d => await ValidateKey("HighStress")
            }
        });

        var upperPressure = measurement.UpperPressure;
        var lowerPressure = measurement.LowerPressure;
        var pressureRecommendation = new RecommendationDto { Theme = "Blood pressure" };

        if (upperPressure < 125)
        {
            if (lowerPressure < 75)
                pressureRecommendation.Key = await ValidateKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Key = await ValidateKey("NormalPressure");
            else
                pressureRecommendation.Key = await ValidateKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }
        else if (upperPressure <= 135)
        {
            if (lowerPressure < 75)
                pressureRecommendation.Key = await ValidateKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Key = await ValidateKey("NormalPressure");
            else
                pressureRecommendation.Key = await ValidateKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }
        else
        {
            if (lowerPressure < 75)
                pressureRecommendation.Key = await ValidateKey("LowPressure");
            else if (lowerPressure <= 87)
                pressureRecommendation.Key = await ValidateKey("NormalPressure");
            else
                pressureRecommendation.Key = await ValidateKey("HighPressure");
            recommendations.Add(pressureRecommendation);
        }

        if (sex is "male")
        {
            recommendations.Add(new RecommendationDto
            {
                Theme = "Fat percentage",
                Key = measurement.FatPercentage switch
                {
                    < 14.0d => await ValidateKey("LowFat"),
                    >= 14.0d and <= 20.0d => await ValidateKey("NormalFat"),
                    > 20.0d => await ValidateKey("HighFat"),
                }
            });
            
            recommendations.Add(new RecommendationDto
            {
                Theme = "Muscle percentage",
                Key = measurement.MusclePercentage switch
                {
                    < 35.0d => await ValidateKey("LowMuscle"),
                    >= 35.0d and <= 45.0d => await ValidateKey("NormalMuscle"),
                    > 45.0d => await ValidateKey("HighMuscle"),
                }
            });
            
            

            // recommendations.AppendLine((measurement.UpperPressure, measurement.LowerPressure) switch
            // {
            //     (< 125, < 75) => await GetRecommendationByKey("LowPressure"),
            //     (>= 125 and <= 135, >= 75 and <= 89) => await GetRecommendationByKey("NormalPressure"),
            //     (> 140, 89) => await GetRecommendationByKey("HighPressure"),
            // });
        }
        else if (sex is "female")
        {
            recommendations.Add(new RecommendationDto
            {
                Theme = "Fat percentage",
                Key = measurement.FatPercentage switch
                {
                    < 19.0d => await ValidateKey("LowFat"),
                    >= 19.0d and <= 25.0d => await ValidateKey("NormalFat"),
                    > 25.0d => await ValidateKey("HighFat"),
                }
            });
            
            recommendations.Add(new RecommendationDto
            {
                Theme = "Muscle percentage",
                Key = measurement.FatPercentage switch
                {
                    < 25.0d => await ValidateKey("LowMuscle"),
                    >= 25.0d and <= 35.0d => await ValidateKey("NormalMuscle"),
                    > 35.0d => await ValidateKey("HighMuscle"),
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

    private async Task<string> ValidateKey(string key)
    {
        var isKeyValid = await _recommendationRepository.IsKeyValid(key);
        if (!isKeyValid)
            throw new ArgumentException($"Recommendation with key {key} was not found.");

        return key;
    }
}