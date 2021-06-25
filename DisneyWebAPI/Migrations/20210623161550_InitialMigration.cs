using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisneyWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    CharacterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterAge = table.Column<int>(type: "int", nullable: false),
                    CharacterWeight = table.Column<int>(type: "int", nullable: false),
                    CharacterStory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "multimedias",
                columns: table => new
                {
                    MultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MultImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MultDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MultRate = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multimedias", x => x.MultId);
                    table.ForeignKey(
                        name: "FK_multimedias_genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMultimedia",
                columns: table => new
                {
                    FilmographyMultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MultCastCharacterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMultimedia", x => new { x.FilmographyMultId, x.MultCastCharacterID });
                    table.ForeignKey(
                        name: "FK_CharacterMultimedia_characters_MultCastCharacterID",
                        column: x => x.MultCastCharacterID,
                        principalTable: "characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMultimedia_multimedias_FilmographyMultId",
                        column: x => x.FilmographyMultId,
                        principalTable: "multimedias",
                        principalColumn: "MultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMultimedia_MultCastCharacterID",
                table: "CharacterMultimedia",
                column: "MultCastCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_multimedias_GenreID",
                table: "multimedias",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMultimedia");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "multimedias");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
