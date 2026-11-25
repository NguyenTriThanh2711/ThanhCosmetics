using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanhCometics.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AnswerSupportsMultipleSkinTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            //này để chuyển quan hệ cũ sang bảng liên kết mới 
            migrationBuilder.Sql("""
                INSERT INTO SkinTypeAnswerSkinTypes (SkinTypeAnswerId, SkinTypeId)
                SELECT SkinTypeAnswerId, SkinTypeId
                FROM SkinTypeAnswers;
                """);

            // Gỡ quan hệ cũ rồi bỏ cột SkinTypeId
            migrationBuilder.DropForeignKey(
                name: "FK_SkinTypeAnswers_SkinTypes_SkinTypeId",
                table: "SkinTypeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SkinTypeAnswers_SkinTypeId",
                table: "SkinTypeAnswers");

            migrationBuilder.DropColumn(
                name: "SkinTypeId",
                table: "SkinTypeAnswers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkinTypeAnswerSkinTypes");
        }
    }
}
