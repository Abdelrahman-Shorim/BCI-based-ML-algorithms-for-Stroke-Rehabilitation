using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BCI_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce5ebbe-546f-492f-a436-3d2da9b9c156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c31f7a8-cf53-4c21-a5f7-6e446b5a6c3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a867cb53-b4d4-4312-aed4-1ccae3385b8d");

            migrationBuilder.DropColumn(
                name: "AttributeName",
                table: "RoleAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeValue",
                table: "RoleAttributes");

            migrationBuilder.AddColumn<Guid>(
                name: "AttributeId",
                table: "RoleAttributes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAttributeValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAttributeValue_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleAttributeValue_RoleAttributes_RoleAttributeId",
                        column: x => x.RoleAttributeId,
                        principalTable: "RoleAttributes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08b244d2-9875-4ab1-a1b7-0e1d105d98f5", "2", "Patient", "Patient" },
                    { "a835837f-0213-4c9b-aa3f-6e30ffb417fa", "1", "Admin", "Admin" },
                    { "c7046a3e-54fe-402f-987b-db2d454b3dcd", "3", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAttributes_AttributeId",
                table: "RoleAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAttributeValue_RoleAttributeId",
                table: "RoleAttributeValue",
                column: "RoleAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAttributeValue_UserId",
                table: "RoleAttributeValue",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAttributes_Attribute_AttributeId",
                table: "RoleAttributes",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAttributes_Attribute_AttributeId",
                table: "RoleAttributes");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "RoleAttributeValue");

            migrationBuilder.DropIndex(
                name: "IX_RoleAttributes_AttributeId",
                table: "RoleAttributes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08b244d2-9875-4ab1-a1b7-0e1d105d98f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a835837f-0213-4c9b-aa3f-6e30ffb417fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7046a3e-54fe-402f-987b-db2d454b3dcd");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "RoleAttributes");

            migrationBuilder.AddColumn<string>(
                name: "AttributeName",
                table: "RoleAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttributeValue",
                table: "RoleAttributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ce5ebbe-546f-492f-a436-3d2da9b9c156", "1", "Admin", "Admin" },
                    { "9c31f7a8-cf53-4c21-a5f7-6e446b5a6c3c", "3", "Doctor", "Doctor" },
                    { "a867cb53-b4d4-4312-aed4-1ccae3385b8d", "2", "Patient", "Patient" }
                });
        }
    }
}
