using Microsoft.EntityFrameworkCore.Migrations;

namespace Moonglade.Data.Migrations
{
    public partial class Update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tag",
                table: "PostTag");

            migrationBuilder.RenameColumn(
                name: "CreateOnUtc",
                table: "Post",
                newName: "CreateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreateOnUtc",
                table: "LocalAccount",
                newName: "CreateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "CustomPage",
                newName: "UpdateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreateOnUtc",
                table: "CustomPage",
                newName: "CreateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "ReplyTimeUtc",
                table: "CommentReply",
                newName: "CreateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreateOnUtc",
                table: "Comment",
                newName: "CreateTimeUtc");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Post",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tag_TagId",
                table: "PostTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tag_TagId",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "CreateTimeUtc",
                table: "Post",
                newName: "CreateOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreateTimeUtc",
                table: "LocalAccount",
                newName: "CreateOnUtc");

            migrationBuilder.RenameColumn(
                name: "UpdateTimeUtc",
                table: "CustomPage",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreateTimeUtc",
                table: "CustomPage",
                newName: "CreateOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreateTimeUtc",
                table: "CommentReply",
                newName: "ReplyTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreateTimeUtc",
                table: "Comment",
                newName: "CreateOnUtc");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tag",
                table: "PostTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
