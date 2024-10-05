using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TenderAutoAppTenderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerCompanyId",
                table: "Tenders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_WinnerCompanyId",
                table: "Tenders",
                column: "WinnerCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_Companies_WinnerCompanyId",
                table: "Tenders",
                column: "WinnerCompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_Companies_WinnerCompanyId",
                table: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_WinnerCompanyId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "WinnerCompanyId",
                table: "Tenders");
        }
    }
}
