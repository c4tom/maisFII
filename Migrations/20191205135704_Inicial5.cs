using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoFundo",
                columns: table => new
                {
                    HistoricoFundoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<float>(nullable: false),
                    FundoId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoFundo", x => x.HistoricoFundoId);
                    table.ForeignKey(
                        name: "FK_HistoricoFundo_Fundo_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundo",
                        principalColumn: "FundoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFundo_FundoId",
                table: "HistoricoFundo",
                column: "FundoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoFundo");
        }
    }
}
