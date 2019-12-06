using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Inicial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Carteira_UsuarioId",
                table: "Carteira",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carteira_Usuario_UsuarioId",
                table: "Carteira",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteira_Usuario_UsuarioId",
                table: "Carteira");

            migrationBuilder.DropIndex(
                name: "IX_Carteira_UsuarioId",
                table: "Carteira");
        }
    }
}
