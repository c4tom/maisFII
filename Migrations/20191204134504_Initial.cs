using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(maxLength: 90, nullable: true),
                    Cep = table.Column<string>(maxLength: 9, nullable: true),
                    Bairro = table.Column<string>(maxLength: 70, nullable: true),
                    Localidade = table.Column<string>(maxLength: 70, nullable: true),
                    Uf = table.Column<string>(maxLength: 2, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Fundo",
                columns: table => new
                {
                    FundoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                name: "HistoricoFundo",
                columns: table => new
                {
                    HistoricoFundoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "OperacaoCompraVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    QuantidadeCota = table.Column<int>(nullable: false),
                    ValorDaCota = table.Column<float>(nullable: false),
                    ValorTaxaDaOperadora = table.Column<float>(nullable: false),
                    OperacaoTipo = table.Column<int>(nullable: false),
                    CarteiraId = table.Column<int>(nullable: true),
                    FundoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacaoCompraVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacaoCompraVenda_Fundo_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundo",
                        principalColumn: "FundoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 70, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    Senha = table.Column<string>(maxLength: 32, nullable: true),
                    Cpf = table.Column<string>(maxLength: 16, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: true),
                    CarteiraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 70, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.CarteiraId);
                    table.ForeignKey(
                        name: "FK_Carteira_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_UsuarioId",
                table: "Carteira",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFundo_FundoId",
                table: "HistoricoFundo",
                column: "FundoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoCompraVenda_CarteiraId",
                table: "OperacaoCompraVenda",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacaoCompraVenda_FundoId",
                table: "OperacaoCompraVenda",
                column: "FundoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CarteiraId",
                table: "Usuario",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperacaoCompraVenda_Carteira_CarteiraId",
                table: "OperacaoCompraVenda",
                column: "CarteiraId",
                principalTable: "Carteira",
                principalColumn: "CarteiraId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Carteira_CarteiraId",
                table: "Usuario",
                column: "CarteiraId",
                principalTable: "Carteira",
                principalColumn: "CarteiraId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteira_Usuario_UsuarioId",
                table: "Carteira");

            migrationBuilder.DropTable(
                name: "HistoricoFundo");

            migrationBuilder.DropTable(
                name: "OperacaoCompraVenda");

            migrationBuilder.DropTable(
                name: "Fundo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
