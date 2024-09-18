using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class V2Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "GymEnrollmentRequests");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.RenameColumn(
                name: "GymId",
                table: "Members",
                newName: "PoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_GymId",
                table: "Members",
                newName: "IX_Members_PoolId");

            migrationBuilder.CreateTable(
                name: "PoolEnrollmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    PoolId = table.Column<int>(type: "integer", nullable: false),
                    EnrollmentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolEnrollmentRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pools",
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
                    table.PrimaryKey("PK_Pools", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Pools_PoolId",
                table: "Members",
                column: "PoolId",
                principalTable: "Pools",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Pools_PoolId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "PoolEnrollmentRequests");

            migrationBuilder.DropTable(
                name: "Pools");

            migrationBuilder.RenameColumn(
                name: "PoolId",
                table: "Members",
                newName: "GymId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_PoolId",
                table: "Members",
                newName: "IX_Members_GymId");

            migrationBuilder.CreateTable(
                name: "GymEnrollmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnrollmentDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false)
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
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Gyms_GymId",
                table: "Members",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");
        }
    }
}
