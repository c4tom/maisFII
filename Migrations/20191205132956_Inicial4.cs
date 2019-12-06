using Microsoft.EntityFrameworkCore.Migrations;

namespace MaisFII.Migrations
{
    public partial class Inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorTaxaDaOperadora",
                table: "OperacaoCompraVenda",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "ValorDaCota",
                table: "OperacaoCompraVenda",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ValorTaxaDaOperadora",
                table: "OperacaoCompraVenda",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "ValorDaCota",
                table: "OperacaoCompraVenda",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
