using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class V2Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03860cd2-8c1b-4135-b64c-a2a4b255b27f", "AQAAAAIAAYagAAAAEBg8unUYtNdAL2Inl2XOHPp+S9Bc2BUB093SnMQ0A5DeqJ8OzmWdjtQMoEIxijFUog==", "6d6abc34-0661-42d1-9aca-2268b947391f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b39026b3-08d6-4586-9a87-d6a3cd5d8354", "AQAAAAIAAYagAAAAEBwIrkoSukYizEfCvvMIvyBa11jPeodicy45z5pVGZdxt2+OFcbB+AX6Ke4o+kFnCg==", "a679e0b2-147d-4b0f-b61f-4758b9ee1989" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5130cd93-c8c0-46bf-8151-aa0e6a912609", "AQAAAAIAAYagAAAAED76NYFN6ziGRIUJRYRWzgdOU25cyfyFpaVT5q79R6FDxRV7e3hg8mSu8GeIyj3E/A==", "aad9bf62-1889-4dd4-a861-15f5d873f9de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b8191c6-ce0e-4e67-b73d-97f1b615b5a7", "AQAAAAIAAYagAAAAEI02c89ZtHlA6tnblIFjXSbdr6TMY9qSb/Jnf2CfFu6TbFlRlogUFXW0wbBsnsN8LA==", "40612b44-ee28-4d0b-9664-31e538f579de" });
        }
    }
}
