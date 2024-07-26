using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenderAutoAppUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Tenders_CompanyId",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TenderId",
                table: "Offers",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Tenders_TenderId",
                table: "Offers",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Tenders_TenderId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_TenderId",
                table: "Offers");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Tenders_CompanyId",
                table: "Offers",
                column: "CompanyId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
