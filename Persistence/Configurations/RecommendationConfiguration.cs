using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Repositories;

namespace Persistence.Configurations;

public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
{
    public void Configure(EntityTypeBuilder<Recommendation> builder)
    {
        builder.HasData(
            // Fat
            new Recommendation
            {
                Id = 1,
                Key = "LowFat",
                Description = "Your fat percentage is extremely low. You should eat more healthy food."
            },
            new Recommendation
            {
                Id = 2,
                Key = "NormalFat",
                Description = "Your fat percentage is great. Continue in the same spirit!"
            },
            new Recommendation
            {
                Id = 3,
                Key = "HighFat",
                Description = "Your fat percentage is high. You should do more cardio, balance your diet and drink more water."
            },
            // Muscle
            new Recommendation
            {
                Id = 4,
                Key = "LowMuscle",
                Description = "Your muscle percentage is low. You should do more strength exercises with no more than 8 reps per set " +
                              "and eat more protein-containing foods."
            },
            new Recommendation
            {
                Id = 5,
                Key = "NormalMuscle",
                Description = "Your muscle percentage is great! Continue in the same spirit!"
            },
            new Recommendation
            {
                Id = 6,
                Key = "HighMuscle",
                Description = "You are a great fellow, your muscle percentage is really high! But you should visit a doctor and get an ultrasound of the heart, " +
                              "as the heart can be enlarged due to high loads"
            },
            //BMI
            new Recommendation
            {
                Id = 7,
                Key = "ExtremelyLowBMI",
                Description = "Your BMI is extremely low! Contact doctor and nutritionist as soon as possible!"
            },
            new Recommendation
            {
                Id = 8,
                Key = "LowBMI",
                Description = "Your BMI is a bit lower than recommended. You should eat more healthy food and balance your diet."
            },
            new Recommendation
            {
                Id = 9,
                Key = "NormalBMI",
                Description = "Your BMI is great! Continue in the same spirit!"
            },
            new Recommendation
            {
                Id = 10,
                Key = "HighBMI",
                Description = "Your BMI is a bit higher than recommended. You should do more sports and balance your diet."
            },
            new Recommendation
            {
                Id = 11,
                Key = "ExtremelyHighBMI",
                Description = "Your BMI is extremely high! Contact nutritionist as soon as possible!"
            },
            //Stress
            new Recommendation
            {
                Id = 12,
                Key = "NormalStress",
                Description = "Your level of stress is normal. Relax and enjoy you life."
            },
            new Recommendation
            {
                Id = 13,
                Key = "HighStress",
                Description = "Your level of stress is really high! Contact a psychologist."
            },
            //Pressure
            new Recommendation
            {
                Id = 14,
                Key = "LowPressure",
                Description = "Your pressure is low. Don't drink a lot of coffee, do not stand for a long time " +
                              "and contact a doctor."
            },
            new Recommendation
            {
                Id = 15,
                Key = "NormalPressure",
                Description = "Your pressure is normal."
            },
            new Recommendation
            {
                Id = 16,
                Key = "HighPressure",
                Description = "Your pressure is high. Don't drink a lot of alcohol, don't smoke cigarettes, " +
                              "and refrain from exercising until you consult a doctor."
            }
        );
    }
}