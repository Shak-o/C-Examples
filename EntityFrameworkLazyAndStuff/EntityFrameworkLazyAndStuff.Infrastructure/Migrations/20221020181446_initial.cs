using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLazyAndStuff.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaTestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaTestModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherTestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTetModelId = table.Column<int>(type: "int", nullable: false),
                    MaTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherTestModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherTestModels_MaTestModels_MaTestId",
                        column: x => x.MaTestId,
                        principalTable: "MaTestModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherTestModels_MaTestId",
                table: "OtherTestModels",
                column: "MaTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherTestModels");

            migrationBuilder.DropTable(
                name: "MaTestModels");
        }
    }
}
