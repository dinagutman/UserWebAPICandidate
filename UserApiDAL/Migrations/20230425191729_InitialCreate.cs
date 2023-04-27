using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApiDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    candidateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    beginYear = table.Column<DateTime>(type: "TEXT", nullable: true),
                    lastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.candidateId);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    languageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.languageId);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesLanguage",
                columns: table => new
                {
                    candidatescandidateId = table.Column<int>(type: "INTEGER", nullable: false),
                    languagesCodeslanguageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesLanguage", x => new { x.candidatescandidateId, x.languagesCodeslanguageId });
                    table.ForeignKey(
                        name: "FK_CandidatesLanguage_candidates_candidatescandidateId",
                        column: x => x.candidatescandidateId,
                        principalTable: "candidates",
                        principalColumn: "candidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesLanguage_language_languagesCodeslanguageId",
                        column: x => x.languagesCodeslanguageId,
                        principalTable: "language",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesLanguage_languagesCodeslanguageId",
                table: "CandidatesLanguage",
                column: "languagesCodeslanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatesLanguage");

            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "language");
        }
    }
}
