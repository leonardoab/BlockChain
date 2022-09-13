using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChain.Repository.Migrations
{
    public partial class updatebasee12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Diferenca",
                table: "Historicos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diferenca",
                table: "Historicos");
        }
    }
}
