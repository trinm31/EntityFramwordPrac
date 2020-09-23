using Microsoft.EntityFrameworkCore.Migrations;

namespace Fluent_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "No name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                },
                comment: " this is user table");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Provider = table.Column<string>(maxLength: 50, nullable: true),
                    UserPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_user_1234",
                        column: x => x.UserPostId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserPostId",
                table: "Products",
                column: "UserPostId");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_name",
                table: "User",
                column: "User_name",
                unique: true,
                filter: "[User_name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
