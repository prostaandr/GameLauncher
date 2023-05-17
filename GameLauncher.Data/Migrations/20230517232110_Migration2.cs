using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLauncher.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableApplications",
                table: "AvailableApplications");

            migrationBuilder.DropIndex(
                name: "IX_AvailableApplications_ApplicationId",
                table: "AvailableApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableApplications",
                table: "AvailableApplications",
                columns: new[] { "ApplicationId", "UserId" });

            migrationBuilder.CreateTable(
                name: "WishListApplications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListApplications", x => new { x.ApplicationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WishListApplications_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListApplications_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableApplications_UserId",
                table: "AvailableApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListApplications_UserId",
                table: "WishListApplications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishListApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableApplications",
                table: "AvailableApplications");

            migrationBuilder.DropIndex(
                name: "IX_AvailableApplications_UserId",
                table: "AvailableApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableApplications",
                table: "AvailableApplications",
                columns: new[] { "UserId", "ApplicationId" });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => new { x.UserId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_WishList_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableApplications_ApplicationId",
                table: "AvailableApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ApplicationId",
                table: "WishList",
                column: "ApplicationId");
        }
    }
}
