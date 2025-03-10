using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apartment_portal_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class IssueTableAddStatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_issues_statusId",
                table: "issues",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "issues_statusId_fkey",
                table: "issues",
                column: "statusId",
                principalTable: "statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "issues_statusId_fkey",
                table: "issues");

            migrationBuilder.DropIndex(
                name: "IX_issues_statusId",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "issues");
        }
    }
}
