using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPost_Models.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogpostCategory",
                columns: table => new
                {
                    BlogpostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategotysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogpostCategory", x => new { x.BlogpostsId, x.CategotysId });
                    table.ForeignKey(
                        name: "FK_BlogpostCategory_BlogPostDS_BlogpostsId",
                        column: x => x.BlogpostsId,
                        principalTable: "BlogPostDS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogpostCategory_CategoryDS_CategotysId",
                        column: x => x.CategotysId,
                        principalTable: "CategoryDS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogpostCategory_CategotysId",
                table: "BlogpostCategory",
                column: "CategotysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogpostCategory");
        }
    }
}
