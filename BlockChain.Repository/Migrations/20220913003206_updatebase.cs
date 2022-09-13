using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChain.Repository.Migrations
{
    public partial class updatebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SaldoDiaro",
                table: "Carteiras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Nfts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarteiraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nfts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nfts_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nfts_CarteiraId",
                table: "Nfts",
                column: "CarteiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nfts");

            migrationBuilder.DropColumn(
                name: "SaldoDiaro",
                table: "Carteiras");
        }
    }
}
