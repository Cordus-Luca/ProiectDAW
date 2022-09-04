using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestanta.Migrations
{
    public partial class AddedOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Shirts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shirts_ShopId",
                table: "Shirts",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shirts_Shops_ShopId",
                table: "Shirts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shirts_Shops_ShopId",
                table: "Shirts");

            migrationBuilder.DropIndex(
                name: "IX_Shirts_ShopId",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Shirts");
        }
    }
}
