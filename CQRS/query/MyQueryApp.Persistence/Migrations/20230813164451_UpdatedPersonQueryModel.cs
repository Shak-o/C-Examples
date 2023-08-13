using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyQueryApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPersonQueryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInMainTable",
                table: "PersonQueryModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInMainTable",
                table: "PersonQueryModels");
        }
    }
}
