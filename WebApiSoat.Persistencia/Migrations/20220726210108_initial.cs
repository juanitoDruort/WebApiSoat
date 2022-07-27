using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSoat.Persistencia.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CiudadVenta",
                schema: "dbo",
                columns: table => new
                {
                    IdCiudadVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permitido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadVenta", x => x.IdCiudadVenta);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "dbo",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreApellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Soat",
                schema: "dbo",
                columns: table => new
                {
                    IdSoat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVenciminetoPolizaActual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlacaAutomotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCiudadVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soat", x => x.IdSoat);
                    table.ForeignKey(
                        name: "FK_Soat_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soat_IdCliente",
                schema: "dbo",
                table: "Soat",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CiudadVenta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Soat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "dbo");
        }
    }
}
