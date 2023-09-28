using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamApacheProjekatBackend.Migrations
{
    /// <inheritdoc />
    public partial class name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLabel_Posts_PostId",
                table: "PostLabel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLabel",
                table: "PostLabel");

            migrationBuilder.RenameTable(
                name: "PostLabel",
                newName: "PostLabels");

            migrationBuilder.RenameIndex(
                name: "IX_PostLabel_PostId",
                table: "PostLabels",
                newName: "IX_PostLabels_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLabels",
                table: "PostLabels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLabels_Posts_PostId",
                table: "PostLabels",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLabels_Posts_PostId",
                table: "PostLabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLabels",
                table: "PostLabels");

            migrationBuilder.RenameTable(
                name: "PostLabels",
                newName: "PostLabel");

            migrationBuilder.RenameIndex(
                name: "IX_PostLabels_PostId",
                table: "PostLabel",
                newName: "IX_PostLabel_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLabel",
                table: "PostLabel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLabel_Posts_PostId",
                table: "PostLabel",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
