using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmacenajeUSACR.Migrations
{
    public partial class mg0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Codigo_cliente",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Codigo_transportista",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "Articulo_custodia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    Codigo_transportista = table.Column<int>(type: "int", nullable: false),
                    TrackingID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Precio_articulo = table.Column<float>(type: "real", nullable: false),
                    Fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha_retiro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo_custodia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulo_retirado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    Codigo_transportista = table.Column<int>(type: "int", nullable: false),
                    TrackingID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha_retiro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo_retirado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_cliente = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Codigo_cliente"),
                    Nombre_completo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Numero_identificacion = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_transportista = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Codigo_transportista"),
                    Nombre_empresa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportista", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo_custodia");

            migrationBuilder.DropTable(
                name: "Articulo_retirado");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Transportista");

            migrationBuilder.DropSequence(
                name: "Codigo_cliente");

            migrationBuilder.DropSequence(
                name: "Codigo_transportista");
        }
    }
}
