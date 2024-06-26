using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BCI_Project.Migrations
{
    /// <inheritdoc />
    public partial class updatedseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f2ff8b1-6ac1-48a9-bae8-f01a4063e2cc", "1", "Admin", "Admin" },
                    { "53a5b440-d100-408a-8be1-f600a930c9dc", "3", "Doctor", "Doctor" },
                    { "d4fadb34-0a98-49e6-82ad-bdbc29a324d2", "2", "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "AttributeName", "AttributeType", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("55a5cf4c-2c6a-4616-9f67-ff2fc3d5aca8"), "Age", "int", false },
                    { new Guid("75574016-d614-4c24-9948-4f6901f5e9ab"), "Gender", "string", false },
                    { new Guid("b30c6114-c44a-4981-b02a-7b447bec69cb"), "PatientHistory", "string", false }
                });

            migrationBuilder.InsertData(
                table: "RoleAttributes",
                columns: new[] { "Id", "AttributeId", "IsDeleted", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1a6cd588-4507-4de3-8d84-c083c8e87be8"), new Guid("75574016-d614-4c24-9948-4f6901f5e9ab"), false, "d4fadb34-0a98-49e6-82ad-bdbc29a324d2" },
                    { new Guid("3444a8c0-aaa1-47c6-9597-75d0dca70ddd"), new Guid("b30c6114-c44a-4981-b02a-7b447bec69cb"), false, "d4fadb34-0a98-49e6-82ad-bdbc29a324d2" },
                    { new Guid("3fc3d9b5-b3ec-4682-b135-9fccbaee7997"), new Guid("55a5cf4c-2c6a-4616-9f67-ff2fc3d5aca8"), false, "d4fadb34-0a98-49e6-82ad-bdbc29a324d2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f2ff8b1-6ac1-48a9-bae8-f01a4063e2cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53a5b440-d100-408a-8be1-f600a930c9dc");

            migrationBuilder.DeleteData(
                table: "RoleAttributes",
                keyColumn: "Id",
                keyValue: new Guid("1a6cd588-4507-4de3-8d84-c083c8e87be8"));

            migrationBuilder.DeleteData(
                table: "RoleAttributes",
                keyColumn: "Id",
                keyValue: new Guid("3444a8c0-aaa1-47c6-9597-75d0dca70ddd"));

            migrationBuilder.DeleteData(
                table: "RoleAttributes",
                keyColumn: "Id",
                keyValue: new Guid("3fc3d9b5-b3ec-4682-b135-9fccbaee7997"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4fadb34-0a98-49e6-82ad-bdbc29a324d2");

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("55a5cf4c-2c6a-4616-9f67-ff2fc3d5aca8"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("75574016-d614-4c24-9948-4f6901f5e9ab"));

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: new Guid("b30c6114-c44a-4981-b02a-7b447bec69cb"));

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
    }
}
