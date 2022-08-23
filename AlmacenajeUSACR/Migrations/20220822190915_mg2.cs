using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmacenajeUSACR.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Codigo_transportista",
                startValue: 100L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Codigo_transportista",
                startValue: 1000L);
        }
    }
}
