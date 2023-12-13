using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RecommendationDontHaveDescriptionAnymore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recommendations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recommendations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Your fat percentage is extremely low. You should eat more healthy food.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Your fat percentage is great. Continue in the same spirit!");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Your fat percentage is high. You should do more cardio, balance your diet and drink more water.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Your muscle percentage is low. You should do more strength exercises with no more than 8 reps per set and eat more protein-containing foods.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Your muscle percentage is great! Continue in the same spirit!");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "You are a great fellow, your muscle percentage is really high! But you should visit a doctor and get an ultrasound of the heart, as the heart can be enlarged due to high loads");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Your BMI is extremely low! Contact doctor and nutritionist as soon as possible!");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Your BMI is a bit lower than recommended. You should eat more healthy food and balance your diet.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Your BMI is great! Continue in the same spirit!");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Your BMI is a bit higher than recommended. You should do more sports and balance your diet.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Your BMI is extremely high! Contact nutritionist as soon as possible!");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Your level of stress is normal. Relax and enjoy you life.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Your level of stress is really high! Contact a psychologist.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "Your pressure is low. Don't drink a lot of coffee, do not stand for a long time and contact a doctor.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "Your pressure is normal.");

            migrationBuilder.UpdateData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "Your pressure is high. Don't drink a lot of alcohol, don't smoke cigarettes, and refrain from exercising until you consult a doctor.");
        }
    }
}
