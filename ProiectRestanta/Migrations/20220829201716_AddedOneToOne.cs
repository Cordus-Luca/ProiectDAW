using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestanta.Migrations
{
    public partial class AddedOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BossId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_BossId",
                table: "Shops",
                column: "BossId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Bosses_BossId",
                table: "Shops",
                column: "BossId",
                principalTable: "Bosses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Bosses_BossId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_BossId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "BossId",
                table: "Shops");
        }
    }
}
