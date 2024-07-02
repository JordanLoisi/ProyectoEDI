using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarZapatilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "zapatillas",
                columns: new[] { "ZapatillaId", "ColoresId", "DeporteId", "Description", "GeneroId", "MarcaId", "Modelo", "Precio" },
                values: new object[,]
                {
                    { 1, 1, 1, "Altas", 1, 1, "Air", 100000m },
                    { 2, 2, 2, "Bajas", 2, 2, "BAD BUNNY", 200000m },
                    { 3, 3, 1, "Medianas", 1, 3, "Roma", 100000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "zapatillas",
                keyColumn: "ZapatillaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "zapatillas",
                keyColumn: "ZapatillaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "zapatillas",
                keyColumn: "ZapatillaId",
                keyValue: 3);
        }
    }
}
