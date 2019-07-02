using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quattro.Core.Migrations
{
    public partial class Inicio : Migration
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
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
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
                    Motivo = table.Column<string>(nullable: true),
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
                    Descripcion = table.Column<string>(nullable: true),
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
                    Numero = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
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
                    Servicio = table.Column<string>(nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(nullable: true),
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
                    Bus = table.Column<string>(nullable: true),
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
                    Servicio = table.Column<string>(nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(nullable: true),
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
                    Servicio = table.Column<string>(nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    DiaCalendarioEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosDia_Calendario_DiaCalendarioEntityId",
                        column: x => x.DiaCalendarioEntityId,
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
                    Servicio = table.Column<string>(nullable: true),
                    Turno = table.Column<int>(nullable: false),
                    Inicio = table.Column<int>(nullable: true),
                    LugarInicio = table.Column<string>(nullable: true),
                    Final = table.Column<int>(nullable: true),
                    LugarFinal = table.Column<string>(nullable: true),
                    LineaId = table.Column<int>(nullable: true),
                    ServicioLineaEntityId = table.Column<int>(nullable: true)
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
                        name: "FK_ServiciosSecundarios_ServiciosLinea_ServicioLineaEntityId",
                        column: x => x.ServicioLineaEntityId,
                        principalTable: "ServiciosLinea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_ServiciosDia_DiaCalendarioEntityId",
                table: "ServiciosDia",
                column: "DiaCalendarioEntityId");

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
                name: "IX_ServiciosSecundarios_ServicioLineaEntityId",
                table: "ServiciosSecundarios",
                column: "ServicioLineaEntityId");
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
