using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRecommendationModelNameAddedDoubleM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recomendations",
                table: "Recomendations");

            migrationBuilder.RenameTable(
                name: "Recomendations",
                newName: "Recommendations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Recomendations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recomendations",
                table: "Recomendations",
                column: "Id");
        }
    }
}
