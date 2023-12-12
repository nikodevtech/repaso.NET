using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "universidad");

            migrationBuilder.CreateTable(
                name: "alumnos_DAW",
                schema: "universidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nombre_alumno = table.Column<string>(type: "text", nullable: false),
                    apellidos_alumno = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    documento_identidad = table.Column<string>(type: "text", nullable: false),
                    fch_nacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos_DAW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas_DAW",
                schema: "universidad",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    modulo = table.Column<string>(type: "text", nullable: false),
                    TecnologiasUsadas = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas_DAW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsignaturaEstudiante",
                schema: "universidad",
                columns: table => new
                {
                    asignatura_id_fk = table.Column<long>(type: "bigint", nullable: false),
                    estudiante_id_fk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaEstudiante", x => new { x.asignatura_id_fk, x.estudiante_id_fk });
                    table.ForeignKey(
                        name: "FK_AsignaturaEstudiante_Asignaturas_DAW_asignatura_id_fk",
                        column: x => x.asignatura_id_fk,
                        principalSchema: "universidad",
                        principalTable: "Asignaturas_DAW",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaEstudiante_alumnos_DAW_estudiante_id_fk",
                        column: x => x.estudiante_id_fk,
                        principalSchema: "universidad",
                        principalTable: "alumnos_DAW",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaEstudiante_estudiante_id_fk",
                schema: "universidad",
                table: "AsignaturaEstudiante",
                column: "estudiante_id_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaEstudiante",
                schema: "universidad");

            migrationBuilder.DropTable(
                name: "Asignaturas_DAW",
                schema: "universidad");

            migrationBuilder.DropTable(
                name: "alumnos_DAW",
                schema: "universidad");
        }
    }
}
