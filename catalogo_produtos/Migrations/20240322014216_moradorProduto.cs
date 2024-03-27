using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace catalogo_produtos.Migrations
{
    /// <inheritdoc />
    public partial class moradorProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoradoresProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoradorId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoradoresProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoradoresProdutos_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoradoresProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoradoresProdutos_MoradorId",
                table: "MoradoresProdutos",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoradoresProdutos_ProdutoId",
                table: "MoradoresProdutos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoradoresProdutos");
        }
    }
}
