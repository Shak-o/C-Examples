using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLazyAndStuff.Infrastructure.Migrations
{
    public partial class moremodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThirdTestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTestModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdTestModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdTestModels_MaTestModels_MaTestModelId",
                        column: x => x.MaTestModelId,
                        principalTable: "MaTestModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThirdTestModels_MaTestModelId",
                table: "ThirdTestModels",
                column: "MaTestModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdTestModels");
        }
    }
}
