using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Repositories;

namespace Persistence.Configurations;

public class RecomendationConfiguration : IEntityTypeConfiguration<Recomendation>
{
    public void Configure(EntityTypeBuilder<Recomendation> builder)
    {
        builder.HasData(
            // Fat
            new Recomendation
            {
                Id = 1,
                Key = "LowFat",
                Description = "Your fat percentage is extremely low. You should eat more healthy food."
            },
            new Recomendation
            {
                Id = 2,
                Key = "NormalFat",
                Description = "Your fat percentage is great. Continue in the same spirit!"
            },
            new Recomendation
            {
                Id = 3,
                Key = "HighFat",
                Description = "Your fat percentage is high. You should do more cardio, balance your diet and drink more water."
            },
            // Muscle
            new Recomendation
            {
                Id = 4,
                Key = "LowMuscle",
                Description = "Your muscle percentage is low. You should do more strength exercises with no more than 8 reps per set " +
                              "and eat more protein-containing foods."
            },
            new Recomendation
            {
                Id = 5,
                Key = "NormalMuscle",
                Description = "Your muscle percentage is great! Continue in the same spirit!"
            },
            new Recomendation
            {
                Id = 6,
                Key = "HighMuscle",
                Description = "You are a great fellow, your muscle percentage is really high! But you should visit a doctor and get an ultrasound of the heart, " +
                              "as the heart can be enlarged due to high loads"
            },
            //BMI
            new Recomendation
            {
                Id = 7,
                Key = "ExtremelyLowBMI",
                Description = "Your BMI is extremely low! Contact doctor and nutritionist as soon as possible!"
            },
            new Recomendation
            {
                Id = 8,
                Key = "LowBMI",
                Description = "Your BMI is a bit lower than recommended. You should eat more healthy food and balance your diet."
            },
            new Recomendation
            {
                Id = 9,
                Key = "NormalBMI",
                Description = "Your BMI is great! Continue in the same spirit!"
            },
            new Recomendation
            {
                Id = 10,
                Key = "HighBMI",
                Description = "Your BMI is a bit higher than recommended. You should do more sports and balance your diet."
            },
            new Recomendation
            {
                Id = 11,
                Key = "ExtremelyHighBMI",
                Description = "Your BMI is extremely high! Contact nutritionist as soon as possible!"
            },
            //Stress
            new Recomendation
            {
                Id = 12,
                Key = "NormalStress",
                Description = "Your level of stress is normal. Relax and enjoy you life."
            },
            new Recomendation
            {
                Id = 13,
                Key = "HighStress",
                Description = "Your level of stress is really high! Contact a psychologist."
            },
            //Pressure
            new Recomendation
            {
                Id = 14,
                Key = "LowPressure",
                Description = "Your pressure is low. Don't drink a lot of coffee, do not stand for a long time " +
                              "and contact a doctor."
            },
            new Recomendation
            {
                Id = 15,
                Key = "NormalPressure",
                Description = "Your pressure is normal."
            },
            new Recomendation
            {
                Id = 16,
                Key = "HighPressure",
                Description = "Your pressure is high. Don't drink a lot of alcohol, don't smoke cigarettes, " +
                              "and refrain from exercising until you consult a doctor."
            }
        );
    }
}