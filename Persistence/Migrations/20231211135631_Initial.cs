using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymEnrollmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEnrollmentRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recomendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    FatPercentage = table.Column<double>(type: "double precision", nullable: false),
                    MusclePercentage = table.Column<double>(type: "double precision", nullable: false),
                    UpperPressure = table.Column<int>(type: "integer", nullable: false),
                    LowerPressure = table.Column<int>(type: "integer", nullable: false),
                    BodyMassIndex = table.Column<double>(type: "double precision", nullable: false),
                    LevelOfStress = table.Column<double>(type: "double precision", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "GymId", "IdentityId", "LastName", "Sex" },
                values: new object[] { 1, new DateOnly(2004, 1, 9), "User", null, "9e224968-33e4-4652-b7b7-8574d048cdb9", "Userovich", "Male" });

            migrationBuilder.InsertData(
                table: "Recomendations",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { 1, "Your fat percentage is extremely low. You should eat more healthy food.", "LowFat" },
                    { 2, "Your fat percentage is great. Continue in the same spirit!", "NormalFat" },
                    { 3, "Your fat percentage is high. You should do more cardio, balance your diet and drink more water.", "HighFat" },
                    { 4, "Your muscle percentage is low. You should do more strength exercises with no more than 8 reps per set and eat more protein-containing foods.", "LowMuscle" },
                    { 5, "Your muscle percentage is great! Continue in the same spirit!", "NormalMuscle" },
                    { 6, "You are a great fellow, your muscle percentage is really high! But you should visit a doctor and get an ultrasound of the heart, as the heart can be enlarged due to high loads", "HighMuscle" },
                    { 7, "Your BMI is extremely low! Contact doctor and nutritionist as soon as possible!", "ExtremelyLowBMI" },
                    { 8, "Your BMI is a bit lower than recommended. You should eat more healthy food and balance your diet.", "LowBMI" },
                    { 9, "Your BMI is great! Continue in the same spirit!", "NormalBMI" },
                    { 10, "Your BMI is a bit higher than recommended. You should do more sports and balance your diet.", "HighBMI" },
                    { 11, "Your BMI is extremely high! Contact nutritionist as soon as possible!", "ExtremelyHighBMI" },
                    { 12, "Your level of stress is normal. Relax and enjoy you life.", "NormalStress" },
                    { 13, "Your level of stress is really high! Contact a psychologist.", "HighStress" },
                    { 14, "Your pressure is low. Don't drink a lot of coffee, do not stand for a long time and contact a doctor.", "LowPressure" },
                    { 15, "Your pressure is normal.", "NormalPressure" },
                    { 16, "Your pressure is high. Don't drink a lot of alcohol, don't smoke cigarettes, and refrain from exercising until you consult a doctor.", "HighPressure" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MemberId",
                table: "Measurements",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GymId",
                table: "Members",
                column: "GymId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymEnrollmentRequests");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Recomendations");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
