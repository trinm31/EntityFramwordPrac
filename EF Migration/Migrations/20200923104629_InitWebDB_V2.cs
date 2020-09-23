using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Migration.Migrations
{
    public partial class InitWebDB_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articleTags",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(nullable: false),
                    TagId = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleTags", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_articleTags_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articleTags_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articleTags_TagId",
                table: "articleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_articleTags_ArticleId_TagId",
                table: "articleTags",
                columns: new[] { "ArticleId", "TagId" },
                unique: true,
                filter: "[TagId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleTags");
        }
    }
}
