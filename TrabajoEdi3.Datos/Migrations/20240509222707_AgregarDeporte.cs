using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDeporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "deportes",
                columns: new[] { "DeporteId", "NombreDeporte" },
                values: new object[,]
                {
                    { 1, "Tenis" },
                    { 2, "Futbol" },
                    { 3, "Padel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "deportes",
                keyColumn: "DeporteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "deportes",
                keyColumn: "DeporteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "deportes",
                keyColumn: "DeporteId",
                keyValue: 3);
        }
    }
}
