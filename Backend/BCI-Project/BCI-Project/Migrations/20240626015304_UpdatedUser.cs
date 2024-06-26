using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BCI_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42fcca9d-313c-4306-af6d-16629e9fc71d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ccd6523-5670-41d7-842f-d7bc4056b573");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8c2f9e6-b977-484e-83fb-3e37fbe49e38");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42fcca9d-313c-4306-af6d-16629e9fc71d", "2", "Patient", "Patient" },
                    { "6ccd6523-5670-41d7-842f-d7bc4056b573", "1", "Admin", "Admin" },
                    { "a8c2f9e6-b977-484e-83fb-3e37fbe49e38", "3", "Doctor", "Doctor" }
                });
        }
    }
}
