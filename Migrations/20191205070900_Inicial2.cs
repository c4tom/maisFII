using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuario",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuario",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Usuario",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Usuario",
                maxLength: 90,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Usuario",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
