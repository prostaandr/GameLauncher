using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLauncher.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_SystemRequirements_MinimumSystemRequirementsId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_SystemRequirements_RecommendedSystemRequirementsId",
                table: "Application");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendedSystemRequirementsId",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinimumSystemRequirementsId",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_SystemRequirements_MinimumSystemRequirementsId",
                table: "Application",
                column: "MinimumSystemRequirementsId",
                principalTable: "SystemRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_SystemRequirements_RecommendedSystemRequirementsId",
                table: "Application",
                column: "RecommendedSystemRequirementsId",
                principalTable: "SystemRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_SystemRequirements_MinimumSystemRequirementsId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_SystemRequirements_RecommendedSystemRequirementsId",
                table: "Application");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendedSystemRequirementsId",
                table: "Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinimumSystemRequirementsId",
                table: "Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_SystemRequirements_MinimumSystemRequirementsId",
                table: "Application",
                column: "MinimumSystemRequirementsId",
                principalTable: "SystemRequirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_SystemRequirements_RecommendedSystemRequirementsId",
                table: "Application",
                column: "RecommendedSystemRequirementsId",
                principalTable: "SystemRequirements",
                principalColumn: "Id");
        }
    }
}
