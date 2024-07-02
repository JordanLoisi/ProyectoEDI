using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CorregirColeccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_zapatillastalles_zapatillastalles_ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles");

            migrationBuilder.DropIndex(
                name: "IX_zapatillastalles_ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles");

            migrationBuilder.DropColumn(
                name: "ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_zapatillastalles_ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles",
                column: "ZapatillasTallesZapatillaTallesId");

            migrationBuilder.AddForeignKey(
                name: "FK_zapatillastalles_zapatillastalles_ZapatillasTallesZapatillaTallesId",
                table: "zapatillastalles",
                column: "ZapatillasTallesZapatillaTallesId",
                principalTable: "zapatillastalles",
                principalColumn: "ZapatillaTallesId");
        }
    }
}
