using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenderAutoAppV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderProducts_TenderProductLists_TenderProductListId",
                table: "TenderProducts");

            migrationBuilder.DropIndex(
                name: "IX_TenderProducts_TenderProductListId",
                table: "TenderProducts");

            migrationBuilder.DropColumn(
                name: "TenderProductListId",
                table: "TenderProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenderProductListId",
                table: "TenderProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TenderProducts_TenderProductListId",
                table: "TenderProducts",
                column: "TenderProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderProducts_TenderProductLists_TenderProductListId",
                table: "TenderProducts",
                column: "TenderProductListId",
                principalTable: "TenderProductLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
