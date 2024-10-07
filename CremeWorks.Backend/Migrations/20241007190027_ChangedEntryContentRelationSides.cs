using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CremeWorks.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntryContentRelationSides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_ContentBlob_ContentId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ContentId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "ContentBlob",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlob_EntryId",
                table: "ContentBlob",
                column: "EntryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlob_Entries_EntryId",
                table: "ContentBlob",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlob_Entries_EntryId",
                table: "ContentBlob");

            migrationBuilder.DropIndex(
                name: "IX_ContentBlob_EntryId",
                table: "ContentBlob");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "ContentBlob");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ContentId",
                table: "Entries",
                column: "ContentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_ContentBlob_ContentId",
                table: "Entries",
                column: "ContentId",
                principalTable: "ContentBlob",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
