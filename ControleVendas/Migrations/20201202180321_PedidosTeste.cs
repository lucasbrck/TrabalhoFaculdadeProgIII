using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVendas.Migrations
{
    public partial class PedidosTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "Estoque");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoModelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoModelId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteModelId",
                        column: x => x.ClienteModelId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteModelId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteModelId",
                table: "Pedidos",
                column: "ClienteModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoModelProdutoModel");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Estoque",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
