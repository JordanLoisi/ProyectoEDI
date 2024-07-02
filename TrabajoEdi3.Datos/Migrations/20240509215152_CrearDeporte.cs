using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CrearDeporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deportes",
                columns: table => new
                {
                    DeporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDeporte = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deportes", x => x.DeporteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deportes");
        }
    }
}
