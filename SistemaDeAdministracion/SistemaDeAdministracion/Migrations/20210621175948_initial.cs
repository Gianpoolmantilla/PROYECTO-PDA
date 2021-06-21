using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeAdministracion.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumno_Carrera_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionDeCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionDeCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignacionDeCursos_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionDeCursos_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionDeCursos_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsAsignacionDeCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    AsignacionDeCursosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsAsignacionDeCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsAsignacionDeCursos_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsAsignacionDeCursos_AsignacionDeCursos_AsignacionDeCursosId",
                        column: x => x.AsignacionDeCursosId,
                        principalTable: "AsignacionDeCursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carrera",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ingenieria en sistemas" },
                    { 2, "arquitectura" },
                    { 3, "analista de sistemas" },
                    { 4, "contador" },
                    { 5, "abogado" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "comunicacion y redes" },
                    { 3, "fisica" },
                    { 4, "Programacion" },
                    { 1, "Matematica" },
                    { 2, "ingles" }
                });

            migrationBuilder.InsertData(
                table: "Profesor",
                columns: new[] { "Id", "Apellido", "Dni", "FechaDeNacimiento", "Nombre", "Sexo" },
                values: new object[,]
                {
                    { 1, "perez", "98765432", new DateTime(1999, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juan", "Masculino" },
                    { 2, "castro", "5452155", new DateTime(1986, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin", "Masculino" },
                    { 3, "romero", "6584255", new DateTime(1972, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanmanuel", "Masculino" },
                    { 4, "benitez", "58766512", new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manuel", "Masculino" }
                });

            migrationBuilder.InsertData(
                table: "Turno",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 2, "tarde" },
                    { 1, "mañana" },
                    { 3, "noche" }
                });

            migrationBuilder.InsertData(
                table: "Alumno",
                columns: new[] { "Id", "Apellido", "CarreraId", "Dni", "Domicilio", "FechaDeIngreso", "FechaDeNacimiento", "Nombre", "Sexo" },
                values: new object[,]
                {
                    { 1, "Hernandez", 1, "12345679", "", new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose", "Masculino" },
                    { 2, "sanchez", 1, "12345679", "av.flores 2458", new DateTime(2020, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos", "Masculino" },
                    { 3, "montes", 3, "12345679", "calle false 123", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduardo", "Masculino" }
                });

            migrationBuilder.InsertData(
                table: "AsignacionDeCursos",
                columns: new[] { "Id", "Anio", "CursoId", "ProfesorId", "Semestre", "TurnoId" },
                values: new object[,]
                {
                    { 1, "2021", 1, 1, 1, 1 },
                    { 2, "2021", 2, 2, 2, 2 },
                    { 3, "2021", 4, 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ItemsAsignacionDeCursos",
                columns: new[] { "Id", "AlumnoId", "AsignacionDeCursosId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CarreraId",
                table: "Alumno",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionDeCursos_CursoId",
                table: "AsignacionDeCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionDeCursos_ProfesorId",
                table: "AsignacionDeCursos",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionDeCursos_TurnoId",
                table: "AsignacionDeCursos",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsAsignacionDeCursos_AlumnoId",
                table: "ItemsAsignacionDeCursos",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsAsignacionDeCursos_AsignacionDeCursosId",
                table: "ItemsAsignacionDeCursos",
                column: "AsignacionDeCursosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsAsignacionDeCursos");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "AsignacionDeCursos");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Turno");
        }
    }
}
