using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTicketApp.Migrations
{
    /// <inheritdoc />
    public partial class Migracio1 : Migration
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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    inserted_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BerletTipusok");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
