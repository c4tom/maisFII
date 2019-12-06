using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 70, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.CarteiraId);
                });

            migrationBuilder.CreateTable(
                name: "Fundo",
                columns: table => new
                {
                    FundoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(maxLength: 20, nullable: false),
                    Segmento = table.Column<string>(maxLength: 10, nullable: true),
                    LinkBMF = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundo", x => x.FundoId);
                });

            migrationBuilder.CreateTable(
                name: "OperacaoCompraVenda",
                columns: table => new
                {
                    OperacaoCompraVendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    QuantidadeCota = table.Column<int>(nullable: false),
                    ValorDaCota = table.Column<float>(nullable: false),
                    ValorTaxaDaOperadora = table.Column<float>(nullable: false),
                    tipo = table.Column<int>(nullable: false),
                    CarteiraId = table.Column<int>(nullable: false),
                    FundoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacaoCompraVenda", x => x.OperacaoCompraVendaId);
                    table.ForeignKey(
                        name: "FK_OperacaoCompraVenda_Carteira_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteira",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperacaoCompraVenda_Fundo_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundo",
                        principalColumn: "FundoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoCompraVenda_CarteiraId",
                table: "OperacaoCompraVenda",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoCompraVenda_FundoId",
                table: "OperacaoCompraVenda",
                column: "FundoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperacaoCompraVenda");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropTable(
                name: "Fundo");
        }
    }
}
