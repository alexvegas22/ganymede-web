using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ganymede_web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benevole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    NomEtablissement = table.Column<string>(type: "TEXT", nullable: true),
                    rolePreferee = table.Column<bool>(type: "INTEGER", nullable: false),
                    LibreFinDeSemaine = table.Column<bool>(type: "INTEGER", nullable: false),
                    LibreJourFeries = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecuFormationPremierSoins = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benevole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BenevoleID = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Role = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horaire_Benevole_BenevoleID",
                        column: x => x.BenevoleID,
                        principalTable: "Benevole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horaire_BenevoleID",
                table: "Horaire",
                column: "BenevoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horaire");

            migrationBuilder.DropTable(
                name: "Benevole");
        }
    }
}
