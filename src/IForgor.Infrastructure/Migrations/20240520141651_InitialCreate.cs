using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IForgor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeskFieldIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskFieldIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeskFieldIds_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskProjectIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskProjectIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeskProjectIds_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskStudySubjectsIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudySubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskStudySubjectsIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeskStudySubjectsIds_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeskFieldIds_DeskId",
                table: "DeskFieldIds",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskProjectIds_DeskId",
                table: "DeskProjectIds",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskStudySubjectsIds_DeskId",
                table: "DeskStudySubjectsIds",
                column: "DeskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskFieldIds");

            migrationBuilder.DropTable(
                name: "DeskProjectIds");

            migrationBuilder.DropTable(
                name: "DeskStudySubjectsIds");

            migrationBuilder.DropTable(
                name: "Desks");
        }
    }
}
