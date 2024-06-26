using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BCI_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43de5f30-7591-46aa-9ecd-0feb77663012");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "931be739-e67c-459e-8da3-6c9d4a615fe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96a1b1b5-576f-46a8-b446-23ec20be1850");

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99cb7c7e-8fd9-4845-94bb-6f81767f558d", "3", "Doctor", "Doctor" },
                    { "b511410c-46a2-4653-871f-e9ea8cc2b9da", "1", "Admin", "Admin" },
                    { "ed0ef4f0-5a81-48c8-a2fa-c9308be2e29a", "2", "Patient", "Patient" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99cb7c7e-8fd9-4845-94bb-6f81767f558d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b511410c-46a2-4653-871f-e9ea8cc2b9da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0ef4f0-5a81-48c8-a2fa-c9308be2e29a");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43de5f30-7591-46aa-9ecd-0feb77663012", "1", "Admin", "Admin" },
                    { "931be739-e67c-459e-8da3-6c9d4a615fe6", "3", "Doctor", "Doctor" },
                    { "96a1b1b5-576f-46a8-b446-23ec20be1850", "2", "Patient", "Patient" }
                });
        }
    }
}
