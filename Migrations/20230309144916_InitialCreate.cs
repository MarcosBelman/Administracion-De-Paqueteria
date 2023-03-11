using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionDePaqueteria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadosDelPaquete",
                columns: table => new
                {
                    codRastreo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaquete = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    numPieza = table.Column<int>(type: "int", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    areaServicio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    estadoActual = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosDelPaquete", x => x.codRastreo);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    codRastreo = table.Column<long>(type: "bigint", nullable: false),
                    idPaquete = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    numPieza = table.Column<int>(type: "int", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    areaServicio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    estadoActual = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.codRastreo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estadosDelPaquete");

            migrationBuilder.DropTable(
                name: "Paquete");
        }
    }
}
