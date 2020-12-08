using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVendas.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoModelProdutoModel");

            migrationBuilder.CreateTable(
                name: "PedidoProdutos",
                columns: table => new
                {
                    ProdutoModelId = table.Column<long>(type: "bigint", nullable: false),
                    PedidoModelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProdutos", x => new { x.PedidoModelId, x.ProdutoModelId });
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Pedidos_PedidoModelId",
                        column: x => x.PedidoModelId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Produtos_ProdutoModelId",
                        column: x => x.ProdutoModelId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProdutos_ProdutoModelId",
                table: "PedidoProdutos",
                column: "ProdutoModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProdutos");

            migrationBuilder.CreateTable(
                name: "PedidoModelProdutoModel",
                columns: table => new
                {
                    PedidosPedidoModelId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutosProdutoModelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoModelProdutoModel", x => new { x.PedidosPedidoModelId, x.ProdutosProdutoModelId });
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Pedidos_PedidosPedidoModelId",
                        column: x => x.PedidosPedidoModelId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Produtos_ProdutosProdutoModelId",
                        column: x => x.ProdutosProdutoModelId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoModelProdutoModel_ProdutosProdutoModelId",
                table: "PedidoModelProdutoModel",
                column: "ProdutosProdutoModelId");
        }
    }
}
