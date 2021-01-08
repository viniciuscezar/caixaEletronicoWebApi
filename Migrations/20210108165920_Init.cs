using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroCedulas.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaixaEletronico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCaixa = table.Column<string>(nullable: true),
                    CedulaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaixaEletronico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cedulas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(nullable: true),
                    CaixaEletronicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cedulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cedulas_CaixaEletronico_CaixaEletronicoId",
                        column: x => x.CaixaEletronicoId,
                        principalTable: "CaixaEletronico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cedulas_CaixaEletronicoId",
                table: "Cedulas",
                column: "CaixaEletronicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cedulas");

            migrationBuilder.DropTable(
                name: "CaixaEletronico");
        }
    }
}
