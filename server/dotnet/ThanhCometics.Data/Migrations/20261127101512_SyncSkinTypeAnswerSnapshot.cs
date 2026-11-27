using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanhCometics.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SyncSkinTypeAnswerSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkinTypeAnswers_SkinTypes_SkinTypeId",
                table: "SkinTypeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SkinTypeAnswers_SkinTypeId",
                table: "SkinTypeAnswers");

            migrationBuilder.DropColumn(
                name: "SkinTypeId",
                table: "SkinTypeAnswers");

            migrationBuilder.CreateTable(
                name: "SkinTypeAnswerSkinTypes",
                columns: table => new
                {
                    SkinTypeAnswerId = table.Column<int>(type: "int", nullable: false),
                    SkinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypeAnswerSkinTypes", x => new { x.SkinTypeAnswerId, x.SkinTypeId });
                    table.ForeignKey(
                        name: "FK_SkinTypeAnswerSkinTypes_SkinTypeAnswers_SkinTypeAnswerId",
                        column: x => x.SkinTypeAnswerId,
                        principalTable: "SkinTypeAnswers",
                        principalColumn: "SkinTypeAnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkinTypeAnswerSkinTypes_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkinTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeAnswerSkinTypes_SkinTypeId",
                table: "SkinTypeAnswerSkinTypes",
                column: "SkinTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkinTypeAnswerSkinTypes");

            migrationBuilder.AddColumn<int>(
                name: "SkinTypeId",
                table: "SkinTypeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeAnswers_SkinTypeId",
                table: "SkinTypeAnswers",
                column: "SkinTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkinTypeAnswers_SkinTypes_SkinTypeId",
                table: "SkinTypeAnswers",
                column: "SkinTypeId",
                principalTable: "SkinTypes",
                principalColumn: "SkinTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
