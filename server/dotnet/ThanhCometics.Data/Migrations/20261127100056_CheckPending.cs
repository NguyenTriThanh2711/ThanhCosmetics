using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanhCometics.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CheckPending : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
