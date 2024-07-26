using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenderAutoAppTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TenderProductLists_TenderId",
                table: "TenderProductLists",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderProductLists_Tenders_TenderId",
                table: "TenderProductLists",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderProductLists_Tenders_TenderId",
                table: "TenderProductLists");

            migrationBuilder.DropIndex(
                name: "IX_TenderProductLists_TenderId",
                table: "TenderProductLists");
        }
    }
}
