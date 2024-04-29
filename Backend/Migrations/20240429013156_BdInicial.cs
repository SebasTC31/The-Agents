using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class BdInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    IdServicio = table.Column<long>(type: "bigint", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAcudiente = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => new { x.Id, x.IdServicio });
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    CantUso = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantServicio = table.Column<int>(type: "int", nullable: false),
                    DescDiagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescDiagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelAcudientes",
                columns: table => new
                {
                    IdAcudiente = table.Column<long>(type: "bigint", nullable: false),
                    Telefono = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelAcudientes", x => new { x.IdAcudiente, x.Telefono });
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<long>(type: "bigint", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acudientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<long>(type: "bigint", nullable: true),
                    FacturaIdServicio = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acudientes_Facturas_FacturaId_FacturaIdServicio",
                        columns: x => new { x.FacturaId, x.FacturaIdServicio },
                        principalTable: "Facturas",
                        principalColumns: new[] { "Id", "IdServicio" });
                });

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

            migrationBuilder.CreateTable(
                name: "Requieres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServicio = table.Column<long>(type: "bigint", nullable: false),
                    ServicioId = table.Column<long>(type: "bigint", nullable: true),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    ProductoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requieres_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requieres_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Sueldo = table.Column<float>(type: "real", nullable: false),
                    TipoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gerentes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcudienteId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Acudientes_AcudienteId",
                        column: x => x.AcudienteId,
                        principalTable: "Acudientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_FacturaId_FacturaIdServicio",
                table: "Acudientes",
                columns: new[] { "FacturaId", "FacturaIdServicio" });

            migrationBuilder.CreateIndex(
                name: "IX_AcudienteTelAcudiente_TelAcudienteIdAcudiente_TelAcudienteTelefono",
                table: "AcudienteTelAcudiente",
                columns: new[] { "TelAcudienteIdAcudiente", "TelAcudienteTelefono" });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ServicioId",
                table: "Empleados",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacturaServicio_IdFacturaId_IdFacturaIdServicio",
                table: "FacturaServicio",
                columns: new[] { "IdFacturaId", "IdFacturaIdServicio" });

            migrationBuilder.CreateIndex(
                name: "IX_Gerentes_UsuarioId",
                table: "Gerentes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_AcudienteId",
                table: "Pacientes",
                column: "AcudienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requieres_ProductoId",
                table: "Requieres",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requieres_ServicioId",
                table: "Requieres",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_User",
                table: "Usuarios",
                column: "User",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcudienteTelAcudiente");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "FacturaServicio");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Requieres");

            migrationBuilder.DropTable(
                name: "TelAcudientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Acudientes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
