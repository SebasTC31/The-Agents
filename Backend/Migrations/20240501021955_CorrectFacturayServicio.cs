using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrectFacturayServicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Facturas_FacturaId_FacturaIdServicio",
                table: "Acudientes");

            migrationBuilder.DropTable(
                name: "FacturaServicio");

            migrationBuilder.DropIndex(
                name: "IX_Acudientes_FacturaId_FacturaIdServicio",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "FacturaIdServicio",
                table: "Acudientes");

            migrationBuilder.AddColumn<long>(
                name: "FacturaId",
                table: "Servicios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FacturaIdServicio",
                table: "Servicios",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AcudienteId",
                table: "Facturas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_FacturaId_FacturaIdServicio",
                table: "Servicios",
                columns: new[] { "FacturaId", "FacturaIdServicio" });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_AcudienteId",
                table: "Facturas",
                column: "AcudienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Acudientes_AcudienteId",
                table: "Facturas",
                column: "AcudienteId",
                principalTable: "Acudientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Facturas_FacturaId_FacturaIdServicio",
                table: "Servicios",
                columns: new[] { "FacturaId", "FacturaIdServicio" },
                principalTable: "Facturas",
                principalColumns: new[] { "Id", "IdServicio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Acudientes_AcudienteId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Facturas_FacturaId_FacturaIdServicio",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_FacturaId_FacturaIdServicio",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_AcudienteId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "FacturaIdServicio",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "AcudienteId",
                table: "Facturas");

            migrationBuilder.AddColumn<long>(
                name: "FacturaId",
                table: "Acudientes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FacturaIdServicio",
                table: "Acudientes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FacturaServicio",
                columns: table => new
                {
                    ServicioId = table.Column<long>(type: "bigint", nullable: false),
                    IdFacturaId = table.Column<long>(type: "bigint", nullable: false),
                    IdFacturaIdServicio = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaServicio", x => new { x.ServicioId, x.IdFacturaId, x.IdFacturaIdServicio });
                    table.ForeignKey(
                        name: "FK_FacturaServicio_Facturas_IdFacturaId_IdFacturaIdServicio",
                        columns: x => new { x.IdFacturaId, x.IdFacturaIdServicio },
                        principalTable: "Facturas",
                        principalColumns: new[] { "Id", "IdServicio" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaServicio_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_FacturaId_FacturaIdServicio",
                table: "Acudientes",
                columns: new[] { "FacturaId", "FacturaIdServicio" });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaServicio_IdFacturaId_IdFacturaIdServicio",
                table: "FacturaServicio",
                columns: new[] { "IdFacturaId", "IdFacturaIdServicio" });

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Facturas_FacturaId_FacturaIdServicio",
                table: "Acudientes",
                columns: new[] { "FacturaId", "FacturaIdServicio" },
                principalTable: "Facturas",
                principalColumns: new[] { "Id", "IdServicio" });
        }
    }
}
