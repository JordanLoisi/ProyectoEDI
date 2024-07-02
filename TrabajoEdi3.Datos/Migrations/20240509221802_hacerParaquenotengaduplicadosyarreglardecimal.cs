using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class hacerParaquenotengaduplicadosyarreglardecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "zapatillas",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_marcas_MarcaNombre",
                table: "marcas",
                column: "MarcaNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generos_GeneroNombre",
                table: "generos",
                column: "GeneroNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deportes_NombreDeporte",
                table: "deportes",
                column: "NombreDeporte",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_colors_ColorName",
                table: "colors",
                column: "ColorName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_marcas_MarcaNombre",
                table: "marcas");

            migrationBuilder.DropIndex(
                name: "IX_generos_GeneroNombre",
                table: "generos");

            migrationBuilder.DropIndex(
                name: "IX_deportes_NombreDeporte",
                table: "deportes");

            migrationBuilder.DropIndex(
                name: "IX_colors_ColorName",
                table: "colors");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "zapatillas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
