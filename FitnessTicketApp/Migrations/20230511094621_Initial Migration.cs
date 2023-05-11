using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTicketApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BerletTipusok",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Megnevezes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ar = table.Column<int>(type: "int", nullable: false),
                    HanyNapigErvenyes = table.Column<int>(type: "int", nullable: false),
                    HanyBelepesreErvenyes = table.Column<int>(type: "int", nullable: false),
                    Torolve = table.Column<bool>(type: "bit", nullable: false),
                    Terem_Id = table.Column<int>(type: "int", nullable: false),
                    Hanyoratol = table.Column<int>(type: "int", nullable: false),
                    Hanyoraig = table.Column<int>(type: "int", nullable: false),
                    NapontaHanyszorHasznalhato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BerletTipusok", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BerletTipusok");
        }
    }
}
