using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbySoftware.Migrations
{
    /// <inheritdoc />
    public partial class Elephantinit10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameDevs_Games_GameID",
                table: "UserGameDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameDevs_Users_UserID",
                table: "UserGameDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMobileDevs_MobileApps_MobileAppID",
                table: "UserMobileDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMobileDevs_Users_UserID",
                table: "UserMobileDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebDevs_Users_UserID",
                table: "UserWebDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebDevs_WebApps_WebAppID",
                table: "UserWebDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWebDevs",
                table: "UserWebDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMobileDevs",
                table: "UserMobileDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameDevs",
                table: "UserGameDevs");

            migrationBuilder.RenameTable(
                name: "UserWebDevs",
                newName: "WebDevs");

            migrationBuilder.RenameTable(
                name: "UserMobileDevs",
                newName: "MobileDevs");

            migrationBuilder.RenameTable(
                name: "UserGameDevs",
                newName: "GameDevs");

            migrationBuilder.RenameIndex(
                name: "IX_UserWebDevs_WebAppID",
                table: "WebDevs",
                newName: "IX_WebDevs_WebAppID");

            migrationBuilder.RenameIndex(
                name: "IX_UserMobileDevs_UserID",
                table: "MobileDevs",
                newName: "IX_MobileDevs_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGameDevs_UserID",
                table: "GameDevs",
                newName: "IX_GameDevs_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebDevs",
                table: "WebDevs",
                columns: new[] { "UserID", "WebAppID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobileDevs",
                table: "MobileDevs",
                columns: new[] { "MobileAppID", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameDevs",
                table: "GameDevs",
                columns: new[] { "GameID", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevs_Games_GameID",
                table: "GameDevs",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevs_Users_UserID",
                table: "GameDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileDevs_MobileApps_MobileAppID",
                table: "MobileDevs",
                column: "MobileAppID",
                principalTable: "MobileApps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileDevs_Users_UserID",
                table: "MobileDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebDevs_Users_UserID",
                table: "WebDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebDevs_WebApps_WebAppID",
                table: "WebDevs",
                column: "WebAppID",
                principalTable: "WebApps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevs_Games_GameID",
                table: "GameDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDevs_Users_UserID",
                table: "GameDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileDevs_MobileApps_MobileAppID",
                table: "MobileDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileDevs_Users_UserID",
                table: "MobileDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_WebDevs_Users_UserID",
                table: "WebDevs");

            migrationBuilder.DropForeignKey(
                name: "FK_WebDevs_WebApps_WebAppID",
                table: "WebDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebDevs",
                table: "WebDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MobileDevs",
                table: "MobileDevs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameDevs",
                table: "GameDevs");

            migrationBuilder.RenameTable(
                name: "WebDevs",
                newName: "UserWebDevs");

            migrationBuilder.RenameTable(
                name: "MobileDevs",
                newName: "UserMobileDevs");

            migrationBuilder.RenameTable(
                name: "GameDevs",
                newName: "UserGameDevs");

            migrationBuilder.RenameIndex(
                name: "IX_WebDevs_WebAppID",
                table: "UserWebDevs",
                newName: "IX_UserWebDevs_WebAppID");

            migrationBuilder.RenameIndex(
                name: "IX_MobileDevs_UserID",
                table: "UserMobileDevs",
                newName: "IX_UserMobileDevs_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GameDevs_UserID",
                table: "UserGameDevs",
                newName: "IX_UserGameDevs_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWebDevs",
                table: "UserWebDevs",
                columns: new[] { "UserID", "WebAppID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMobileDevs",
                table: "UserMobileDevs",
                columns: new[] { "MobileAppID", "UserID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameDevs",
                table: "UserGameDevs",
                columns: new[] { "GameID", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameDevs_Games_GameID",
                table: "UserGameDevs",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameDevs_Users_UserID",
                table: "UserGameDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMobileDevs_MobileApps_MobileAppID",
                table: "UserMobileDevs",
                column: "MobileAppID",
                principalTable: "MobileApps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMobileDevs_Users_UserID",
                table: "UserMobileDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebDevs_Users_UserID",
                table: "UserWebDevs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebDevs_WebApps_WebAppID",
                table: "UserWebDevs",
                column: "WebAppID",
                principalTable: "WebApps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
