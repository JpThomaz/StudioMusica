using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudioMusica.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faixas",
                columns: table => new
                {
                    FaixaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbunsAlbumID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faixas", x => x.FaixaID);
                });

            migrationBuilder.CreateTable(
                name: "Musicos",
                columns: table => new
                {
                    MusicoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaixasFaixaID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicos", x => x.MusicoID);
                    table.ForeignKey(
                        name: "FK_Musicos_Faixas_FaixasFaixaID",
                        column: x => x.FaixasFaixaID,
                        principalTable: "Faixas",
                        principalColumn: "FaixaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    AlbumID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAlbum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusicoID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Albuns_Musicos_MusicoID",
                        column: x => x.MusicoID,
                        principalTable: "Musicos",
                        principalColumn: "MusicoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instrumentos",
                columns: table => new
                {
                    InstrumentoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusicosMusicoID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumentos", x => x.InstrumentoID);
                    table.ForeignKey(
                        name: "FK_Instrumentos_Musicos_MusicosMusicoID",
                        column: x => x.MusicosMusicoID,
                        principalTable: "Musicos",
                        principalColumn: "MusicoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_MusicoID",
                table: "Albuns",
                column: "MusicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Faixas_AlbunsAlbumID",
                table: "Faixas",
                column: "AlbunsAlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentos_MusicosMusicoID",
                table: "Instrumentos",
                column: "MusicosMusicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Musicos_FaixasFaixaID",
                table: "Musicos",
                column: "FaixasFaixaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Faixas_Albuns_AlbunsAlbumID",
                table: "Faixas",
                column: "AlbunsAlbumID",
                principalTable: "Albuns",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albuns_Musicos_MusicoID",
                table: "Albuns");

            migrationBuilder.DropTable(
                name: "Instrumentos");

            migrationBuilder.DropTable(
                name: "Musicos");

            migrationBuilder.DropTable(
                name: "Faixas");

            migrationBuilder.DropTable(
                name: "Albuns");
        }
    }
}
