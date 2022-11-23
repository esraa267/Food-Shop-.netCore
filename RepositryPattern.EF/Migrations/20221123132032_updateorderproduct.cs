using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositryPattern.EF.Migrations
{
    /// <inheritdoc />
    public partial class updateorderproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderProducts_products_ProductId",
                table: "orderProducts");

            migrationBuilder.DropIndex(
                name: "IX_orderProducts_ProductId",
                table: "orderProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_ProductId",
                table: "orderProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderProducts_products_ProductId",
                table: "orderProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
