using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChain.Repository.Migrations
{
    public partial class atualizarbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CotacaoDolar",
                table: "Historicos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CotacaoMafaDolar",
                table: "Historicos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CotacaoMafaReal",
                table: "Historicos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TipoCarteira",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoCarteiraEmpresa",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoTransacao",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValorTransacaoDolar",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValorTransacaoReal",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoCarteiraEmpresa",
                table: "Carteiras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CotacaoDolar",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "CotacaoMafaDolar",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "CotacaoMafaReal",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "TipoCarteira",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "TipoCarteiraEmpresa",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "TipoTransacao",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "ValorTransacaoDolar",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "ValorTransacaoReal",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "TipoCarteiraEmpresa",
                table: "Carteiras");
        }
    }
}
