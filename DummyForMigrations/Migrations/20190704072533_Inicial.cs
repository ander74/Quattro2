using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DummyForMigrations.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companeros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 64, nullable: true),
                    Apellidos = table.Column<string>(maxLength: 128, nullable: true),
                    Telefono = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Calificacion = table.Column<int>(nullable: false),
                    Deuda = table.Column<int>(nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorasAjenas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Horas = table.Column<decimal>(nullable: false),
                    Motivo = table.Column<string>(maxLength: 256, nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasAjenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 64, nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(maxLength: 32, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 128, nullable: true),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Servicio = table.Column<string>(maxLength: 32, nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(maxLength: 64, nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(maxLength: 64, nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    TomaDeje = table.Column<int>(nullable: true),
                    Euros = table.Column<decimal>(nullable: false),
                    Notas = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EsFranqueo = table.Column<bool>(nullable: false),
                    EsFestivo = table.Column<bool>(nullable: false),
                    HuelgaParcial = table.Column<bool>(nullable: false),
                    HorasHuelga = table.Column<decimal>(nullable: false),
                    Trabajadas = table.Column<decimal>(nullable: false),
                    Acumuladas = table.Column<decimal>(nullable: false),
                    Nocturnas = table.Column<decimal>(nullable: false),
                    Desayuno = table.Column<bool>(nullable: false),
                    Comida = table.Column<bool>(nullable: false),
                    Cena = table.Column<bool>(nullable: false),
                    Bus = table.Column<string>(maxLength: 32, nullable: true),
                    IncidenciaId = table.Column<int>(nullable: true),
                    RelevoId = table.Column<int>(nullable: true),
                    SustiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendario_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendario_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendario_Companeros_RelevoId",
                        column: x => x.RelevoId,
                        principalTable: "Companeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendario_Companeros_SustiId",
                        column: x => x.SustiId,
                        principalTable: "Companeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosLinea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Servicio = table.Column<string>(maxLength: 32, nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(maxLength: 64, nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(maxLength: 64, nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    TomaDeje = table.Column<int>(nullable: true),
                    Euros = table.Column<decimal>(nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosLinea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosLinea_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosDia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Servicio = table.Column<string>(maxLength: 32, nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(maxLength: 64, nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(maxLength: 64, nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    DiaCalendarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosDia_Calendario_DiaCalendarioId",
                        column: x => x.DiaCalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiciosDia_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosSecundarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Servicio = table.Column<string>(maxLength: 32, nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(maxLength: 64, nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(maxLength: 64, nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    ServicioLineaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosSecundarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosSecundarios_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiciosSecundarios_ServiciosLinea_ServicioLineaId",
                        column: x => x.ServicioLineaId,
                        principalTable: "ServiciosLinea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 1, 0, "Repite día anterior", "Incidencia Protegida.", 0 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 15, 14, "En otro destino", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 14, 13, "Sanción", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 13, 12, "Hacemos el día", "Incidencia Protegida.", 5 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 12, 11, "Nos hacen el día", "Incidencia Protegida.", 1 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 11, 10, "F.N.R. año anterior", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 10, 9, "F.N.R. año actual", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 16, 15, "Huelga", "Incidencia Protegida.", 5 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 9, 8, "Permiso", "Incidencia Protegida.", 6 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 7, 6, "Enferma/o", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 6, 5, "Franqueo a trabajar", "Incidencia Protegida.", 2 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 5, 4, "F.O.D.", "Incidencia Protegida.", 3 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 4, 3, "Vacaciones", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 3, 2, "Franqueo", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 2, 1, "Trabajo", "Incidencia Protegida.", 1 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 8, 7, "Accidentada/o", "Incidencia Protegida.", 4 });

            migrationBuilder.InsertData(
                table: "Incidencias",
                columns: new[] { "Id", "Codigo", "Descripcion", "Notas", "Tipo" },
                values: new object[] { 17, 16, "Día por H. Acumuladas", "Incidencia Protegida.", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_IncidenciaId",
                table: "Calendario",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_LineaId",
                table: "Calendario",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_RelevoId",
                table: "Calendario",
                column: "RelevoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_SustiId",
                table: "Calendario",
                column: "SustiId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosDia_DiaCalendarioId",
                table: "ServiciosDia",
                column: "DiaCalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosDia_LineaId",
                table: "ServiciosDia",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosLinea_LineaId",
                table: "ServiciosLinea",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosSecundarios_LineaId",
                table: "ServiciosSecundarios",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosSecundarios_ServicioLineaId",
                table: "ServiciosSecundarios",
                column: "ServicioLineaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorasAjenas");

            migrationBuilder.DropTable(
                name: "ServiciosDia");

            migrationBuilder.DropTable(
                name: "ServiciosSecundarios");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "ServiciosLinea");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Companeros");

            migrationBuilder.DropTable(
                name: "Lineas");
        }
    }
}
