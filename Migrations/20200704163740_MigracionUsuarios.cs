using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibreriaMVC.Migrations
{
    public partial class MigracionUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    nacionalidad = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    pApellido = table.Column<string>(nullable: true),
                    sApellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoresID = table.Column<int>(nullable: false),
                    EditorialesID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AutoresID",
                        column: x => x.AutoresID,
                        principalTable: "Autor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Editorial_EditorialesID",
                        column: x => x.EditorialesID,
                        principalTable: "Editorial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutoresID",
                table: "Libro",
                column: "AutoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_EditorialesID",
                table: "Libro",
                column: "EditorialesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
