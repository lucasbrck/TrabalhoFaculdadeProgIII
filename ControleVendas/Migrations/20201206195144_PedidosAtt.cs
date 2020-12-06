using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVendas.Migrations
{
    public partial class PedidosAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProdutoModelId",
                table: "Pedidos",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoModelId",
                table: "Pedidos");
        }
    }
}
