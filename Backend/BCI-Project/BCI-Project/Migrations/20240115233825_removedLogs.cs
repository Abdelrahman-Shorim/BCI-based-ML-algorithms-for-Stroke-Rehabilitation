using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCI_Project.Migrations
{
    /// <inheritdoc />
    public partial class removedLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMovements_GameLog_GameLogId",
                table: "GameMovements");

            migrationBuilder.DropTable(
                name: "GameLog");

            migrationBuilder.RenameColumn(
                name: "GameLogId",
                table: "GameMovements",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameMovements_GameLogId",
                table: "GameMovements",
                newName: "IX_GameMovements_GameId");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accuracy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_LevelId",
                table: "Game",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PatientId",
                table: "Game",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMovements_Game_GameId",
                table: "GameMovements",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMovements_Game_GameId",
                table: "GameMovements");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameMovements",
                newName: "GameLogId");

            migrationBuilder.RenameIndex(
                name: "IX_GameMovements_GameId",
                table: "GameMovements",
                newName: "IX_GameMovements_GameLogId");

            migrationBuilder.CreateTable(
                name: "GameLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accuracy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameLog_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameLog_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameLog_LevelId",
                table: "GameLog",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLog_PatientId",
                table: "GameLog",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMovements_GameLog_GameLogId",
                table: "GameMovements",
                column: "GameLogId",
                principalTable: "GameLog",
                principalColumn: "Id");
        }
    }
}
