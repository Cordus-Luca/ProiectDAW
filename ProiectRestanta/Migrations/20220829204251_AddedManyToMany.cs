using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestanta.Migrations
{
    public partial class AddedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShirtDesigns",
                columns: table => new
                {
                    ShirtId = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtDesigns", x => new { x.ShirtId, x.DesignId });
                    table.ForeignKey(
                        name: "FK_ShirtDesigns_Designs_ShirtId",
                        column: x => x.ShirtId,
                        principalTable: "Designs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShirtDesigns_Shirts_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShirtDesigns_DesignId",
                table: "ShirtDesigns",
                column: "DesignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShirtDesigns");
        }
    }
}
