using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoEdi3.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CrearZapatillasylascollecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "zapatillas",
                columns: table => new
                {
                    ZapatillaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    DeporteId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    ColoresId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zapatillas", x => x.ZapatillaId);
                    table.ForeignKey(
                        name: "FK_zapatillas_colors_ColoresId",
                        column: x => x.ColoresId,
                        principalTable: "colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zapatillas_deportes_DeporteId",
                        column: x => x.DeporteId,
                        principalTable: "deportes",
                        principalColumn: "DeporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zapatillas_generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zapatillas_marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_zapatillas_ColoresId",
                table: "zapatillas",
                column: "ColoresId");

            migrationBuilder.CreateIndex(
                name: "IX_zapatillas_DeporteId",
                table: "zapatillas",
                column: "DeporteId");

            migrationBuilder.CreateIndex(
                name: "IX_zapatillas_GeneroId",
                table: "zapatillas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_zapatillas_MarcaId",
                table: "zapatillas",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zapatillas");
        }
    }
}
