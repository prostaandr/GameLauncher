using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLauncher.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Review_UserId_ApplicationId",
                table: "Review");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId_ApplicationId",
                table: "Review",
                columns: new[] { "UserId", "ApplicationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Review_UserId_ApplicationId",
                table: "Review");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId_ApplicationId",
                table: "Review",
                columns: new[] { "UserId", "ApplicationId" });
        }
    }
}
