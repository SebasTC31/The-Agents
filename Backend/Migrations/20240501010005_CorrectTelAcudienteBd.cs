using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrectTelAcudienteBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcudienteTelAcudiente");

            migrationBuilder.AddForeignKey(
                name: "FK_TelAcudientes_Acudientes_IdAcudiente",
                table: "TelAcudientes",
                column: "IdAcudiente",
                principalTable: "Acudientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelAcudientes_Acudientes_IdAcudiente",
                table: "TelAcudientes");

            migrationBuilder.CreateTable(
                name: "AcudienteTelAcudiente",
                columns: table => new
                {
                    AcudienteId = table.Column<long>(type: "bigint", nullable: false),
                    TelAcudienteIdAcudiente = table.Column<long>(type: "bigint", nullable: false),
                    TelAcudienteTelefono = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcudienteTelAcudiente", x => new { x.AcudienteId, x.TelAcudienteIdAcudiente, x.TelAcudienteTelefono });
                    table.ForeignKey(
                        name: "FK_AcudienteTelAcudiente_Acudientes_AcudienteId",
                        column: x => x.AcudienteId,
                        principalTable: "Acudientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcudienteTelAcudiente_TelAcudientes_TelAcudienteIdAcudiente_TelAcudienteTelefono",
                        columns: x => new { x.TelAcudienteIdAcudiente, x.TelAcudienteTelefono },
                        principalTable: "TelAcudientes",
                        principalColumns: new[] { "IdAcudiente", "Telefono" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcudienteTelAcudiente_TelAcudienteIdAcudiente_TelAcudienteTelefono",
                table: "AcudienteTelAcudiente",
                columns: new[] { "TelAcudienteIdAcudiente", "TelAcudienteTelefono" });
        }
    }
}
